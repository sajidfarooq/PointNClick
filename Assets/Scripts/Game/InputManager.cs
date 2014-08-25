using UnityEngine;
using System.Collections;

/// <summary>
/// A generic handler for input. Supports touch and mouse, as well as down, up and drag events
/// It tells the GameController which object was clicked/touched/interacted with.
/// </summary>
public class InputManager : MonoBehaviour {

	/// <summary>
	/// The game controller reference.
	/// </summary>
	public GameController GameControllerRef;
	
	/// <summary>
	/// A generic handler for input. Supports touch and mouse, as well as down, up and drag events
	/// </summary>
	void Update () 
	{
		if(Input.GetKeyUp("q") )
		   Application.Quit();

		if(Input.GetKeyUp("s") )
			GameControllerRef.SaveGame();

		if(Input.GetKeyUp("l") )
			GameControllerRef.LoadGame();

		if (Input.touchCount > 0)
		{
			switch(Input.GetTouch(0).phase)
			{
			case TouchPhase.Began:
				OnDown(Input.GetTouch(0).position);
				break;
				
			case TouchPhase.Ended:
				OnUp();
				break;
				
			case TouchPhase.Moved:
				OnDrag(Input.GetTouch(0).position);
				break;
				
			}
			
		}
		else
		{
			if (Input.GetMouseButtonDown(0))
			{

				OnDown (Input.mousePosition);
			}
			else if(Input.GetMouseButton(0))
			{
				OnDrag (Input.mousePosition);
			}
			else if(Input.GetMouseButtonUp(0))
			{
				OnUp();
			}
		}
	}


	void OnDown(Vector3 cursorPosition)
	{
		Ray ray = Camera.main.ScreenPointToRay(cursorPosition);
		
		RaycastHit hit;
		
		if(Physics.Raycast(ray, out hit) )
		{
			GameControllerRef.ObjectClicked(hit.collider.gameObject);
		}
	}

	void OnDrag(Vector3 cursorPosition)
	{
		//Stub
		Debug.Log ("STUB: OnDrag()");
	}

	void OnUp()
	{
		//Stub
		Debug.Log ("STUB: OnUp()");
	}
}
