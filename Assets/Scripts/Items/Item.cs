using UnityEngine;
using System.Collections;

/// <summary>
/// The most basic element in a scene. 
/// By default, this is "observable" in the game. I.e, when the user clicks on
/// it, its "Info" will be displayed in the console.
/// All other elements in the scene inherit from this class.
/// </summary>
public class Item : MonoBehaviour 
{
	public string Name;
	public string Info;
	public int SceneIndex;
	public int ItemIndex;
	
}
