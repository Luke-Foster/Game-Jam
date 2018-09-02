using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour {

	public int levelnum;
	// Use this for initialization
	void Start () {
		levelnum = Application.loadedLevel;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider col)
	{
		if (col.tag == "Player") {
			if ((levelnum + 1) < 2)
				Application.LoadLevel ((levelnum + 1));
			else
				Application.LoadLevel (0);
				//main menu
				//Application.Quit;
			}
	}
}
