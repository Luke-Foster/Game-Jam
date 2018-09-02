using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour {

	private Vector3 currentPos, destinationPos;
	private bool Slide = false;
	public float speed, step;

	public Player_Controller Controller;
	public bool One_Play = true;


	public bool PP1 = false, PP2 = false, Pressure = false, Powered = false;

	// Use this for initialization
	void Start () {
		close ();

	}

	// Update is called once per frame
	void Update () {
		
		if (Slide) 
		{
			float step = speed * Time.deltaTime;
			this.transform.position = Vector3.MoveTowards(this.transform.position, destinationPos, step);

		}
		if (Pressure) {
			if (PP1 && PP2) {
				open ();
			}

		} else if (Powered)
			open ();
	}

	public void close()
	{
		speed = 5f;
		currentPos = this.transform.position;
		destinationPos = currentPos;
		destinationPos.y -= 1;
		Slide = true;
	}

	public void open()
	{
		speed = 5f;
		currentPos = this.transform.position;
		destinationPos = currentPos;
		destinationPos.y += 1;
		Slide = true;
		if (One_Play) {
			Playfx ();
		}

	}

	public void Playfx()
	{
			Controller.source.clip = Controller.Doorfx;
			Controller.source.Play ();
			One_Play = false;
	}
}
