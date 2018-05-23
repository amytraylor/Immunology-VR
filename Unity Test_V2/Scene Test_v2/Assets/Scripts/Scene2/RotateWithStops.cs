using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateWithStops : MonoBehaviour {

    public float speed = 10.0f;
    public bool isRotating;

    private float speedReset;
    
    // Use this for initialization
    void Start () {
        //isRotating = true;
        speedReset = speed;

        InvokeRepeating("SetBoolBack", 0, 8);
	}
	
	// Update is called once per frame
	void Update () {

        if (isRotating)
        {
            speed = speedReset;
            transform.Rotate(Vector3.up * Time.deltaTime * speed);
        }
        else
        {
            speed = 0f;
            transform.Rotate(Vector3.up * Time.deltaTime * speed);
        }
        

    }

    void SetBoolBack()
    {
        isRotating = true;
    }
}
