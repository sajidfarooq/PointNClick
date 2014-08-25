using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

/// <summary>
/// The "View" for the Inventory, according to the classic MVC pattern.
/// This takes care of the visual aspects of the inventory.
/// </summary>
public class InventoryView : MonoBehaviour 
{
	//Slots are limited so they can be manually linked via the inspector
	public List<Text> Slots;

	int _selectedItem = -1;	//-1 = Deselect

	/// <summary>
	/// Updates the view based on a fresh list provided by the controller.
	/// </summary>
	/// <param name="inventoryList">Inventory list.</param>
	public void UpdateView(InventoryItem[] inventoryList)
	{
	
		// Go through the list, assigning items to slots, and
		// marking as "empty" the remaining ones
		for(int i=0; i< Slots.Count; i++)
		{
			if(i < inventoryList.Length)
				Slots[i].text = inventoryList[i].Name;
			else
				Slots[i].text = "Empty";
		}


		// Warn designer that inventory isn't scrollable yet, in case he/she designs
		// for more pickableitems than three.
		if(Slots.Count < inventoryList.Length)
		{

			Debug.LogWarning("For now, slots limited to three. \n Need to add sliders to view more items");
		}
	}

	/// <summary>
	/// Gets the index of the selected item. Used by the ViewController 
	/// 
	/// </summary>
	/// <returns>The selected item index.</returns>
	public int GetSelectedItemIndex()
	{
		return _selectedItem;
	}
	
	/// <summary>
	/// One of the slots has been clicked. If not, then Deselect has been chosen.
	/// </summary>
	public void OnInventoryClicked()
	{
		bool isSlotSelected = false;

		//Find out which of the slots has been toggled on
		for(int i=0; i< Slots.Count; i++)
		{
			// The "Toggle" component is 2 levels above the "label" (my slot), 
			// so we need the transform.parent.parent to access it
			Toggle toggleItem = Slots[i].transform.parent.parent.gameObject.GetComponent<Toggle>();

			//If it is toggled on, then remember its id, and set isSlotSelected = true so
			// we remember that a slot is selected (rather than "Deselect")
			if(toggleItem.isOn == true)
			{
				_selectedItem = i;
				isSlotSelected = true;
			}
		}

		// Slot isnt selected, so choose "Deselect", which is -1
		if(isSlotSelected == false)
		{
			_selectedItem = -1;
		}

	}

}
