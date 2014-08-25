using UnityEngine;
using System.Collections;
using UnityEngine.UI;

/// <summary>
/// The brains behind the entire Game. 
/// 
/// For pragmatic reasons, this class doesn't follow MVC completely. 
/// A single "view" cannot really exist for the whole game. 
/// There is the GameController, and its model _gameState (the GameXML class).
/// The other controllers in the game such as the InventoryController, control
/// their own "views". All these views are collectively controlled by 
/// GameController, instead of having a single view.
/// </summary>
public class GameController : MonoBehaviour 
{

	/// <summary>
	/// A link to the original XML file
	/// </summary>
	public TextAsset XMLfile;
	/// <summary>
	/// A reference to the Console Panel. This should actually be a "controller"
	/// that controls a Console View. However, we don't need anything fancy.
	/// We manipulate the text of the view directly to save time.
	/// On a longer project, this would be ideal for MVC.
	/// </summary>
	public Text ConsoleText;
	/// <summary>
	/// A reference to the Inventory Controller. It allows adding and consuming
	/// of items to the inventory. The Inventory follows the MVC pattern 
	/// so we only need to talk to the controller
	/// </summary>
	public InventoryController Inventory;
	/// <summary>
	/// The index of the scene that the game starts in. This should be read from XML too
	/// at some stage. For now, its convenient to set it in the inspector since changing
	/// this is very rare anyway.
	/// </summary>
	public int StartingScene = 0;

	int _currentScene;
	Schemas.GameXML _gameState;

	// Use this for initialization
	void Awake () 
	{
		_currentScene = StartingScene;

		//StartNewGame();

	}

	/// <summary>
	/// Starts a new game. The method is public so we can call it from external button clicks etc.
	/// </summary>
	public void StartNewGame()
	{
		LoadNewGameStateFromXML();
		InitializeCurrentScene();
	}

	/// <summary>
	/// Handler for the Object Click Event. It expects an InputManager to tell it which 
	/// Object has been clicked. The GameController then proceeds to figure out what kind 
	/// of object it is (Navigation, Pickable etc), and what action to take.
	/// </summary>
	/// <param name="clickedObject">Clicked object.</param>
	public void ObjectClicked(GameObject clickedObject)
	{
		//What type of object is this?
		//Its a navigation object
		if(clickedObject.GetComponent<NavigationItem>() != null)
		{
			NavItemClicked(clickedObject);
		}

		//Its a pickable item
		else if(clickedObject.GetComponent<PickableItem>() != null)
		{
			ConsoleText.text = PickableItemClicked(clickedObject);
		}

		//Its a standard item
		else if(clickedObject.GetComponent<Item>() != null)
		{
			ConsoleText.text = ItemClicked(clickedObject); 
		}

		//Now check one level up
		else if(clickedObject.transform.parent != null)
		{
			//Navigation item?
			if(clickedObject.transform.parent.gameObject.GetComponent<NavigationItem>() != null ) //Check its parent 
			{
				NavItemClicked(clickedObject.transform.parent.gameObject);
			}
			// Pickable Item?
			else if(clickedObject.transform.parent.gameObject.GetComponent<PickableItem>() != null)
			{
				ConsoleText.text = PickableItemClicked(clickedObject.transform.parent.gameObject);
			}
			// Standard Item?
			else if(clickedObject.transform.parent.GetComponent<Item>() != null)	//Check its parent
			{
				ConsoleText.text = ItemClicked(clickedObject.transform.parent.gameObject); 
			}
		}

	}

								// ------------------------
								// GAME SAVE/LOAD FUNCTIONS
								// ------------------------
	//--------------------------------------------------------------------------------------------------------------------


	/// <summary>
	/// Saves the game. Mainly, the Game Model XML file, and items in the inventory
	/// </summary>
	public void SaveGame()
	{
		SaveLoad.Save(_gameState);
		Inventory.SaveInventory();
	}

	/// <summary>
	/// Loads the game. Mainly, the Game Model XML file, and items in the inventory
	/// If a previously saved game is not found, it simply starts a new game
	/// </summary>
	public void LoadGame()
	{
		//Load the game state
		_gameState = SaveLoad.Load();


		if(_gameState != null)
		{
			ClearCurrentScene();		//Clear old scene
			InitializeCurrentScene();	//Init new scene
			Inventory.LoadInventory();	//Load inventory as well
		}
		//If its null, just start a new game instead
		else
		{
			// Previous saved game not found. Just start new game.
			StartNewGame();
		}
	}


	void LoadNewGameStateFromXML()
	{
		
		_gameState = SaveLoad.LoadFromXMLString( XMLfile.text );
	}

								// ------------------------------
								// SCENE INITIALIZATION FUNCTIONS
								// ------------------------------
	//--------------------------------------------------------------------------------------------------------------------
	

	void InitializeCurrentScene()
	{
		// ------
		// ITEMS
		// -----
		//Instantiate all items first (for now I am just loading one)

		//Load item reference from XML file
		var loadedResource = Resources.Load(_gameState.Scene[_currentScene].Item.ResourcePath);
		if(loadedResource != null)
		{
			//Instantiate the item
			GameObject itemObject = Instantiate(loadedResource) as GameObject;
			//Make it interactive
			Item item = itemObject.AddComponent<Item>();

			//Load the relevant data into the PickableItem component from the XML
			item.Name = _gameState.Scene[_currentScene].Item.Name;
			item.Info = _gameState.Scene[_currentScene].Item.Info;
		}

		// --------------
		// PICKABLE ITEMS
		// --------------
		//Instantiate all PickableItems (for now I am just loading one, no loops)
		for(int i=0; i< _gameState.Scene[_currentScene].PickableItem.Length; i++)
		{
			//Load pickableitem reference from XML file
			loadedResource = Resources.Load(_gameState.Scene[_currentScene].PickableItem[i].ResourcePath);
			if(loadedResource != null)
			{
				//If its "picked" already, we don't need to load it. Otherwise proceed to load
				if(_gameState.Scene[_currentScene].PickableItem[i].IsPicked == false)
				{
					//Instantiate the item
					GameObject pickableItemObject = Instantiate(loadedResource ) as GameObject;

					//Make it "pickable"
					PickableItem pickableItem = pickableItemObject.AddComponent<PickableItem>();

					//Load the relevant data into the PickableItem component from the XML
					pickableItem.Name = _gameState.Scene[_currentScene].PickableItem[i].Name;
					pickableItem.Info = _gameState.Scene[_currentScene].PickableItem[i].Info;
					pickableItem.PickedMessage = _gameState.Scene[_currentScene].PickableItem[i].PickedMessage;
					pickableItem.RequiredItem = _gameState.Scene[_currentScene].PickableItem[i].RequiredItem;
					pickableItem.IsPicked = _gameState.Scene[_currentScene].PickableItem[i].IsPicked;
					pickableItem.SceneIndex = _currentScene;
					pickableItem.ItemIndex = i;
				}
			}
			else
			{
				// We shouldn't be here. If we are, then we are in trouble.
				// Provide debugging info as a warning log.
				string log = "Pickable Item " + i + " of scene '" + _gameState.Scene[_currentScene].id +"' is null. \n";
				log += "Check path: Resources\\" + _gameState.Scene[_currentScene].PickableItem[i].ResourcePath;
				Debug.LogWarning (log);
			}
		}
		
		// ----------------
		// NAVIGATION ITEMS
		// ----------------
		//Instantiate all NavigationItems
		for(int i=0; i< _gameState.Scene[_currentScene].NavigationItem.Length; i++)
		{
			//Load navigationitem reference from XML file
			loadedResource = Resources.Load(_gameState.Scene[_currentScene].NavigationItem[i].ResourcePath);
			if(loadedResource != null)
			{
				//Instantiate the item
				GameObject navigationItemObject = Instantiate(loadedResource) as GameObject;

				//Make it "navigatable"
				NavigationItem navigationItem = navigationItemObject.AddComponent<NavigationItem>();

				//Load the relevant data into the PickableItem component from the XML
				navigationItem.Name = _gameState.Scene[_currentScene].NavigationItem[i].Name;
				navigationItem.Info = _gameState.Scene[_currentScene].NavigationItem[i].Info;
				navigationItem.SceneName = _gameState.Scene[_currentScene].NavigationItem[i].SceneName;
			}
			else
			{
				// We shouldn't be here. If we are, then we are in trouble.
				// Provide debugging info as a warning log.
				string log = "Navigation Item " + i + " of scene '" + _gameState.Scene[_currentScene].id +"' is null. \n";
				log += "Check path: Resources\\" + _gameState.Scene[_currentScene].NavigationItem[i].ResourcePath;
				Debug.LogWarning (log);
			}
		}


		//Tell us where we are now.
		ConsoleText.text = _gameState.Scene[_currentScene].id;
	}
	
	void ClearCurrentScene()
	{
		//All objects that are destroyed when scene changes (i.e, are scene specific), are
		// tagged as "Scene Specific".
		var rootObjects = GameObject.FindGameObjectsWithTag("Scene Specific");

		for(int i=0;i<rootObjects.Length;i++)
			Destroy(rootObjects[i]);
	}


							// -----------------
							// ITEM WAS CLICKED
							// -----------------
	//--------------------------------------------------------------------------------------

	/// <summary>
	/// An ordinary item was clicked. Show its info.
	/// </summary>
	/// <returns>The clicked.</returns>
	/// <param name="clickedObject">Clicked object.</param>
	string ItemClicked(GameObject clickedObject)
	{
		Item anItem = clickedObject.GetComponent<Item>();
		return anItem.Info;
	}

	/// <summary>
	/// Respond to a navigation button/object being clicked. I.e, teleport
	/// to a different scene.
	/// </summary>
	/// <param name="clickedObject">Clicked object.</param>
	void NavItemClicked(GameObject clickedObject)
	{
		//CLEAR THE SCENE
		ClearCurrentScene();
		NavigationItem navItem = clickedObject.GetComponent<NavigationItem>();
		
		//Which scene must we navigate to
		for(int i=0; i< _gameState.Scene.Length; i++)
		{
			if(_gameState.Scene[i].id.Equals(navItem.SceneName))
			{
				_currentScene = i;
				break;
			}
		}
		
		//INITIALIZE NEW SCENE
		InitializeCurrentScene();
	}

	/// <summary>
	/// A pickable item was clicked. It may also have a prereq that
	/// must be present and selected in inventory before being picked.
	/// </summary>
	/// <returns>The item clicked.</returns>
	/// <param name="clickedObject">Clicked object.</param>
	string PickableItemClicked(GameObject clickedObject)
	{
		PickableItem anItem = clickedObject.GetComponent<PickableItem>();
		string returnMessage =  anItem.PickedMessage;

		InventoryItem anInventoryItem = new InventoryItem();

		anInventoryItem.Name = anItem.Name;
		anInventoryItem.IconPath = "Default";	//Todo: This is default for now, but we can load it for visual indication

		if(anItem.RequiredItem == "" || anItem.RequiredItem == "None" || anItem.RequiredItem == null )
		{
			Inventory.AddInventoryItem(anInventoryItem);
		}
		//Looks like we need another item first
		//Is inventory item selecte?
		else if(Inventory.IsInventoryItemSelected() == true) 
		{
			string selItemName = Inventory.GetSelectedItem().Name;
			//Is the selected item indeed the prerequisite item?
			if(selItemName == anItem.RequiredItem)
			{
				//Consume the selected item in order to gain the new item
				Inventory.ConsumeInventoryItem();
			}
			//We don't have the prerequisite item so just observe it
			else
			{
				returnMessage = anItem.Info;
				return returnMessage;
			}
		}
		//We don't have the prerequisite item so just observe it
		else
		{
			returnMessage = anItem.Info;
			return returnMessage;
		}

		//Item picked. Destroy the item and return its "picked" message
		_gameState.Scene[anItem.SceneIndex].PickableItem[anItem.ItemIndex].IsPicked = true;
		Destroy(clickedObject);
		return returnMessage;
	}

}
