using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour {

	public GameObject platform;
	public float speed;
	public Transform currentPoint;
	public Transform[] points;
	public int pointSelection;
	public bool on = false;


	// Use this for initialization
	void Start () {
		currentPoint = points[pointSelection];
	}

	// Update is called once per frame
	void Update () {

		if (on) {

			platform.transform.position = Vector3.MoveTowards (platform.transform.position, currentPoint.position, Time.deltaTime * speed);
			if (platform.transform.position == currentPoint.position) {
				pointSelection++;

				if (pointSelection == points.Length) {
					pointSelection = 0;
				}
				currentPoint = points [pointSelection];
			}

		}

	}
}
