using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuScript : MonoBehaviour {

//	public Button play;
//	public Button control;
//	public Button quit;
//	public Button back;

	void Start () 
	{
//		Application.LoadLevel (0);
//		Application.LoadLevel (1);
//		Application.LoadLevel (2);
	}
	
	void Update () 
	{
		
	}
	public void LoadMainMenu ()
	{
		Application.LoadLevel (0);
	}
	public void LoadControls ()
	{
		Application.LoadLevel (1);
	}
	public void LoadGame ()
	{
		Application.LoadLevel (2);
	}
	public void LoadQuit ()
	{
		Application.Quit ();
	}
}
