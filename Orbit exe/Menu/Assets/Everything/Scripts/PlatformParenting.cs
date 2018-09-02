using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformParenting : MonoBehaviour {



	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter (Collider col)
	{
		if (col.tag == "Player")
		{
			col.transform.parent = gameObject.transform;
		}
	}

	void OnTriggerExit (Collider col)
	{
		
			col.transform.parent = null;

	}
}
