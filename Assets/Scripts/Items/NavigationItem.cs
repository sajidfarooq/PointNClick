using UnityEngine;
using System.Collections;

/// <summary>
/// Inherits from "Item". Enhances Item by allowing a click to 
/// teleport the user to another scene. Usually used for navigation, 
/// and is placed on "arrows" etc.
/// </summary>
public class NavigationItem : Item 
{
	/// <summary>
	/// The name of the scene that should be loaded when the item is clicked.
	/// </summary>
	public string SceneName;	
}
