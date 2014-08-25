using UnityEngine;
using System.Collections;

/// <summary>
/// Inherits from "Item". It enhances Item by making it "pickable".
/// </summary>
public class PickableItem : Item 
{
	/// <summary>
	/// The item that must be in the inventory in order to pick the current item.
	/// e.g: If current item is "Lock" then we expect "Key" to be selected in the inventory.
	/// </summary>
	public string RequiredItem;

	/// <summary>
	/// The message to be displayed when the item is picked up.
	/// </summary>
	public string PickedMessage;

	/// <summary>
	/// Status of the item. Has it been picked up or not.
	/// </summary>
	public bool IsPicked = false;
}
