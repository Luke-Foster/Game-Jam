using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour {

	public bool on = false;
	public GameObject Holder_Start, Holder_End;
	public Player_Controller Controller;
	public LineRenderer line;

	public Vector3 offsetCorrection = new Vector3 (0f, 10f, 0f);

	public float width = 0f;
	public Color Colour = Color.red;

	CapsuleCollider Capsule;


	// Use this for initialization
	void Start () {

		line = this.GetComponent<LineRenderer> ();
		line.enabled = false;

		line.SetPosition (0, (Holder_Start.transform.position+ offsetCorrection));
		line.SetPosition (1, (Holder_End.transform.position+ offsetCorrection));
		line.SetColors (Colour, Colour);
		line.SetWidth (width, width);

		Capsule = gameObject.AddComponent <CapsuleCollider>();
		Capsule.radius = width / 2;
		Capsule.center = new Vector3(0, (offsetCorrection.y * 2) ,(Holder_End.transform.position - Holder_Start.transform.position).magnitude / 2);
		Capsule.direction = 2;

		//Capsule.transform.position = Holder_Start.transform.position + (Holder_End.transform.position - Holder_Start.transform.position) / 2;
		Capsule.transform.LookAt (Holder_End.transform.position);
		Capsule.height = (Holder_End.transform.position - Holder_Start.transform.position).magnitude;

		Capsule.isTrigger = true;
		Capsule.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (on) {
			Capsule.enabled = true;
			line.enabled = true;
			Debug.Log ("Power On");

		} 
		else {
			line.enabled = false;
			Capsule.enabled = false;
		}
	}

	void OnTriggerEnter(Collider col)
	{

		if (col.tag == "Player") 
		{
			Controller.Respawn ();
		} 
		else if (col.tag != "Holder") 
		{
			Destroy (col.gameObject);
		} 
		else
		{
			Debug.Log ("Hit Holder");
		}

	}
}

