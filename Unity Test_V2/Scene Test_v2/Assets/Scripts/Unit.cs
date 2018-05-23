using UnityEngine;
using System.Collections;

public class Unit : MonoBehaviour {


	public bool selected = false;
	public float floorOffset = 1;
	public float speed = 10;
	public float stopDistanceOffset = 0.5f;


	private Vector3 moveToDest = Vector3.zero;

	
	// Update is called once per frame
	void Update () {
		if (GetComponent<Renderer>().isVisible && Input.GetMouseButton(0)) 
		{
			Vector3 camPos = Camera.main.WorldToScreenPoint(transform.position);
			camPos.y = CameraOperator.InvertMouseY (camPos.y);
			selected = CameraOperator.selection.Contains (camPos);

			if (selected)
				GetComponent<Renderer>().material.color = Color.red;
			else
				GetComponent<Renderer>().material.color = Color.white;
		}

		if (selected && Input.GetMouseButtonUp (1)) 
		{
			Vector3 destination = CameraOperator.GetDestination ();

			if (destination != Vector3.zero) 
			{
				moveToDest = destination;
				moveToDest.y += floorOffset;
			}
		}

		UpdateMove ();
	
	}

	private void UpdateMove()
	{
		if (moveToDest != Vector3.zero && transform.position != moveToDest) 
		{
			Vector3 direction = (moveToDest - transform.position).normalized;
			direction.y = 0;
			transform.GetComponent<Rigidbody>().velocity = direction * speed;

			if (Vector3.Distance (transform.position, moveToDest) < stopDistanceOffset)
				moveToDest = Vector3.zero;
		} 
		else
			transform.GetComponent<Rigidbody>().velocity = Vector3.zero;
	}
}
