using UnityEngine;
using System.Collections;

/// <summary>
/// Stores the name, and optionally a path to the icon for an 
/// item that is currently in the inventory
/// </summary>
[System.Serializable]
public class InventoryItem 
{
	/// <summary>
	/// Name of the Item
	/// </summary>
	public string Name;

	/// <summary>
	/// Path to an optional resources that represents an icon for when the item is in the inventory.
	/// By default, the name will appear in the inventory rather than an image.
	/// NOTE: Not implemented yet
	/// </summary>
	public string IconPath;
}
