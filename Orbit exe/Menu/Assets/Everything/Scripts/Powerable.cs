using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerable : MonoBehaviour {

	public bool Powered = false;
	public GameObject[] Object;
	public GameObject CurrentObject;
	public int Object_number;
	public Laser LaserScript;
	public Platform PlatformScript;
	public Door DoorScript;

	// Use this for initialization
	void Start () {
		Object_number = Object.Length;
	}
	
	// Update is called once per frame
	void Update () {
		if (Powered) {
			for (int i = 0; i < Object_number; i++) {
				if (Object [i].tag == "Platform") {
					PlatformScript =	Object [i].GetComponent (typeof(Platform)) as Platform;
					Move ();
				} else if (Object [i].tag == "Laser") {
					LaserScript =	Object [i].GetComponent (typeof(Laser)) as Laser;
					Lasers ();
				} else if (Object [i].tag == "Door") {
					DoorScript =	Object [i].GetComponent (typeof(Door)) as Door;
					Open ();
				}
			}
				
		}
		else {
			for (int i = 0; i < Object_number; i++) {
				if (Object[i].tag == "Platform") {
					PlatformScript =	Object[i].GetComponent (typeof(Platform)) as Platform;
					PlatformScript.on = false;
				} else if (Object[i].tag == "Laser") {
					LaserScript =	Object[i].GetComponent (typeof(Laser)) as Laser;
					LaserScript.on = false;
				}
			}
		}
	}

	public void Move ()
	{
		Debug.Log("Call Move");
		PlatformScript.on = true;
	}

	public void Lasers ()
	{
		//Debug.Log("Call Laser");
		LaserScript.on = true;
	}

	public void Open()
	{
		DoorScript.Powered = true;
	}
}
