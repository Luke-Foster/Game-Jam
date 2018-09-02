using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact : MonoBehaviour {

	public GameObject Player, Player_Orb, Object_Orb, Light, Lever, BallRelease, BlackLight, YellowLight;
	public Powerable Power;
	public Player_Controller Controller;
	public bool InArea = false;
	public bool OrbHolder = false;
	public bool FuseBox = false;
	public bool AlwaysOn = false;
	public bool Ballbutton = false;
	public BoxCollider ReleasePanel;

	public GameObject spark;

	public Animator anim;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (AlwaysOn)
			Power.Powered = true;

		if(InArea)
		{
			if (Input.GetKeyDown ("e")) {
				anim.SetTrigger ("Interact");
				if (OrbHolder) {
					if (Power.Powered) {
						Controller.source.clip = Controller.PowerUpfx;
						Controller.source.Play ();
						Power.Powered = false;
						Controller.Powered = true;
						Player_Orb.SetActive (true);
						Object_Orb.SetActive (false);
					} else {
						Controller.source.clip = Controller.PowerDownfx;
						Controller.source.Play ();
						Power.Powered = true;
						Controller.Powered = false;
						Player_Orb.SetActive (false);
						Object_Orb.SetActive (true);
					}
				} else if (FuseBox) 
				{
					Controller.source.clip = Controller.Powerfx;
					Controller.source.Play ();
					AlwaysOn = true;
					BlackLight.SetActive (false);
					YellowLight.SetActive (true);
					spark.SetActive (true);
				}
				else if (Ballbutton) 
				{Controller.source.clip = Controller.Buttonfx;
					Controller.source.Play ();
					ReleasePanel =	BallRelease.GetComponent<BoxCollider> ();
					ReleasePanel.isTrigger = true;


				}

			} 
			}
		}
		

	void OnTriggerEnter(Collider col)
	{
		InArea = true;
	}

	void OnTriggerExit(Collider col)
	{
		InArea = false;
	}
}
