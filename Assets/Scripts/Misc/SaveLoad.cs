using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Xml.Serialization;
using System.Xml;

/// <summary>
/// A utility class that performs saving and loading throughout the game.
/// Its static so it can be called from anywhere in the engine.
/// </summary>
public static class SaveLoad 
{
	/// <summary>
	/// Save the currently running game so that it can be loaded later. This is used
	/// by the GameController.
	/// </summary>
	/// <param name="xmlFile">Xml file.</param>
	public static void Save(Schemas.GameXML xmlFile)
	{
		BinaryFormatter bf = new BinaryFormatter();
		FileStream file = File.Create (Application.persistentDataPath + "GameProgress.PnC");
		bf.Serialize(file, xmlFile);
		file.Close();
	}

	/// <summary>
	/// Used by GameController to load the previously saved Game.
	/// </summary>
	public static Schemas.GameXML Load()
	{
		if(File.Exists(Application.persistentDataPath + "GameProgress.PnC")) 
		{
			BinaryFormatter bf = new BinaryFormatter();
			FileStream file = File.Open(Application.persistentDataPath + "GameProgress.PnC", FileMode.Open);
			Schemas.GameXML xmlObject = (Schemas.GameXML)bf.Deserialize(file);
			file.Close();

			return xmlObject;
		}

		//Looks like there is a bug
		return null;
	}

	/// <summary>
	/// When playing a new game, this loads the Game State from a given XML file, passed in as a string.
	/// Used by the GameController.
	/// </summary>
	/// <returns>The from XML string.</returns>
	/// <param name="xmlString">Xml string.</param>
	public static Schemas.GameXML LoadFromXMLString(string xmlString)
	{
		var serializer = new XmlSerializer(typeof (Schemas.GameXML));
		var reader = XmlReader.Create(new StringReader(xmlString));
		return (Schemas.GameXML) serializer.Deserialize(reader);
	}


	/// <summary>
	/// A helper utility that saves the inventory to an external file.
	/// Used by InventoryController
	/// </summary>
	/// <param name="inventoryItems">Inventory items.</param>
	public static void SaveInventory(List<InventoryItem> inventoryItems)
	{
		BinaryFormatter bf = new BinaryFormatter();
		FileStream file = File.Create (Application.persistentDataPath + "Inventory.PnC");
		bf.Serialize(file, inventoryItems);
		file.Close();
	}

	/// <summary>
	/// A helper utility that loads the inventory from an external file.
	/// Used by InventoryController
	/// </summary>
	/// <returns>The inventory.</returns>
	public static List<InventoryItem> LoadInventory()
	{
		if(File.Exists(Application.persistentDataPath + "Inventory.PnC")) 
		{
			BinaryFormatter bf = new BinaryFormatter();
			FileStream file = File.Open(Application.persistentDataPath + "Inventory.PnC", FileMode.Open);
			List<InventoryItem> inventoryItems = (List<InventoryItem>)bf.Deserialize(file);
			file.Close();
			
			return inventoryItems;
		}
		
		//Looks like there is a bug
		return null;
	}
	
}
