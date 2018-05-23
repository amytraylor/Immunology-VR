using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChemoSensorVisual : MonoBehaviour {

    public float range;
    public Transform chemokine;
    public GameObject sensor;
    public GameObject hand;
    public int min;
    public int max;
    

    private float dist;
    private float distFactor;
    private float rotationAngle;

    
    
	// Update is called once per frame
	void Update () {

        dist = Vector3.Distance(chemokine.position, transform.position);
        //Debug.Log(dist);

        distFactor = dist / range;
        //Debug.Log(distFactor);

        if (dist <= 180)
        {
            rotationAngle = Mathf.Lerp(max, min, distFactor);
        }
        else
        {
            rotationAngle = 0;
        }

        //Debug.Log(rotationAngle);

        hand.transform.localEulerAngles = new Vector3(0, rotationAngle, 0);
      
        //hand.transform.Rotate(Vector3.up*rotationAngle*Time.deltaTime, Space.Self);
    }

  
}
