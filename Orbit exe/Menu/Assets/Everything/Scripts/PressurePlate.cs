using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour {

	public Door door;
	public int PPNum = 0;
	public GameObject pad;
	public GameObject newpos, StartPos;

	// Use this for initialization
	void Start () {
		StartPos.transform.position = pad.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
	


	}

	void OnTriggerEnter(Collider col)
	{
		if (col.tag == "Player" || col.tag == "Pickup") {	
			pad.transform.position = newpos.transform.position;

			if (PPNum == 1) {
				Debug.Log ("pressure 1");
				door.PP1 = true;
			}
			if (PPNum == 2) {
				Debug.Log ("null pressure 2");
				door.PP2 = true;
			}
		}

	}
		void OnTriggerExit(Collider col) 
		{
			
			pad.transform.position = StartPos.transform.position;

		if (PPNum == 1) {Debug.Log ("null pressure 1");

			door.PP1 = false;
		}
		if (PPNum == 2) {
			Debug.Log ("null pressure 2");
			door.PP2 = false;
		}

		}
	}


