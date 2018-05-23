using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatedLine : MonoBehaviour {

    private LineRenderer emptyLine;
    private float counter;
    private float dist;

    public Transform origin;
    public Transform destination;

    public float lineDrawSpeed = 6f;

	// Use this for initialization
	void Start () {

        emptyLine = GetComponent<LineRenderer>();
        emptyLine.SetPosition(0, origin.position);

        dist = Vector3.Distance(origin.position, destination.position);
	}
	
	// Update is called once per frame
	void Update () {
		
        if(counter < dist)
        {
            counter += .1f / lineDrawSpeed;
            float x = Mathf.Lerp(0, dist, counter);

            Vector3 pointA = origin.position;
            Vector3 pointB = destination.position;

            Vector3 pointAlongLine = x * Vector3.Normalize(pointB - pointA) + pointA;

            emptyLine.SetPosition(1, pointAlongLine);
           


        }
	}
}
