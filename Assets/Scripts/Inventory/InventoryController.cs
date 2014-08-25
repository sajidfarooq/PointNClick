using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// The Inventory controller, in the classic MVC pattern.
/// This is the brains behind the Inventory, or the "glue code" between
/// the view, and the model
/// Generally used by the GameController to initiate item pickup and consumption in inventory.
/// </summary>
public class InventoryController : MonoBehaviour 
{
	/// <summary>
	/// A reference to the View object for the inventory
	/// </summary>
	public InventoryView View;


	private List<InventoryItem> _inventory;
	//private int _selectedItem = -1;

	void Awake()
	{
		_inventory = new List<InventoryItem>();
	}

	/// <summary>
	/// Adds an item to the inventory, and then updates the view to reflect the addition
	/// </summary>
	/// <param name="anItem">An item.</param>
	public void AddInventoryItem(InventoryItem anItem)
	{
		_inventory.Add(anItem);

		InventoryItem[] inventoryCopy = new InventoryItem[_inventory.Count];
		_inventory.CopyTo(inventoryCopy);

		View.UpdateView(inventoryCopy);
	}

	/// <summary>
	/// Removes the inventory item at the specified index
	/// </summary>
	/// <param name="index">Index.</param>
	public void RemoveInventoryItem(int index)
	{
		_inventory.RemoveAt(index);

		InventoryItem[] inventoryCopy = new InventoryItem[_inventory.Count];
		_inventory.CopyTo(inventoryCopy);

		View.UpdateView(inventoryCopy);
	}

	/// <summary>
	/// Consumes the currently selected inventory item.
	/// </summary>
	public void ConsumeInventoryItem()
	{
		RemoveInventoryItem( GetSelectedItemIndex() );
	}
	

	/// <summary>
	/// Determines whether an inventory item has been selected.
	/// </summary>
	/// <returns><c>true</c> if inventory item has been selected; otherwise, <c>false</c>.</returns>
	public bool IsInventoryItemSelected()
	{
		if(GetSelectedItemIndex() > -1)
			return true;
		else
			return false;
	}

	/// <summary>
	/// Gets the selected item from the inventory.
	/// </summary>
	/// <returns>The selected item.</returns>
	public InventoryItem GetSelectedItem()
	{
		return _inventory[GetSelectedItemIndex()];
	}

	/// <summary>
	/// Gets the index of the selected item from the inventory
	/// </summary>
	/// <returns>The selected item index.</returns>
	int GetSelectedItemIndex()
	{
		return View.GetSelectedItemIndex();
	}

	/// <summary>
	/// Saves the inventory to an external file.
	/// </summary>
	public void SaveInventory()
	{
		SaveLoad.SaveInventory(_inventory);
	}

	/// <summary>
	/// Loads the inventory from an external file.
	/// </summary>
	public void LoadInventory()
	{
		//Load the new inventory
		_inventory = SaveLoad.LoadInventory();

		if(_inventory != null)
		{
			//Get a copy, so we are not passing by reference
			InventoryItem[] inventoryCopy = new InventoryItem[_inventory.Count];
			_inventory.CopyTo(inventoryCopy);

			//Tell view to update itsself
			View.UpdateView(inventoryCopy);
		}
		else
		{
			Debug.LogWarning("Inventory file is either corrupt or couldn't be found.");
		}

	}
	
}
