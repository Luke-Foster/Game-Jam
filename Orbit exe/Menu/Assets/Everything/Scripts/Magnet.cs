using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magnet : MonoBehaviour {

	public GameObject Held, Item_Holder;
	public float Time_limit;
	public Player_Controller P_Controller;
	public float Range = 5f;
	public float Force = 2000f, Delay = 2f;
	public Camera cam;
	public float Drag_Speed = 5f, RotateSpeed = 125f, modifier = 100f;
	public Rigidbody Held_Body;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Delay -= Time.deltaTime;
		if (P_Controller.Powered) {
			
			if (Input.GetButtonDown ("Fire1") && Held == null) {

				Debug.Log ("Clicked");



				Ray ray = cam.ScreenPointToRay (Input.mousePosition);
				RaycastHit hit;
				if (Physics.Raycast (ray, out hit, Range)) {

					if (hit.transform.gameObject.tag == "Pickup")
					{
						P_Controller.source.clip = P_Controller.Magnetfx;
						P_Controller.source.Play ();
						Held = hit.transform.gameObject;
						Delay = 1;
					}
				}
			}
			else if (Held != null) {
				Held_Body = Held.GetComponent<Rigidbody> ();
				Held_Body.useGravity = false;
				Held.transform.position = Vector3.MoveTowards (Held.transform.position, Item_Holder.transform.position, Time.deltaTime * Drag_Speed);
			    Held.transform.Rotate (Vector3.forward * (RotateSpeed * Time.deltaTime));
			    Held.transform.Rotate (Vector3.left * (RotateSpeed * Time.deltaTime));


				if (Input.GetKey("q"))
					{
					Held_Body.useGravity = true;
					Held_Body = null;
					Held = null;
					}

				if (Input.GetButton ("Fire1") && Delay <= 0f) 
				{
					Force += modifier * Time.deltaTime;

				}
				if (Input.GetButtonUp ("Fire1") && Delay <= 0f) {
					Held_Body.AddForce (( transform.forward * Force) / Held_Body.mass);
					Held_Body.useGravity = true;
					Held_Body = null;
					Held = null;

					Force = 500f;
				}
			}
	}
}

}

