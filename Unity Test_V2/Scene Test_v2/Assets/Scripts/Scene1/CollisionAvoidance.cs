using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionAvoidance : MonoBehaviour {


    public Transform front;
    public Transform back;

    private TouchpadMove _tpmScript;



    private void Awake()
    {
        _tpmScript = GetComponent<TouchpadMove>();
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        DetectCollision();


	}

    void DetectCollision()
    {
        RaycastHit hitFront;
        Ray rayFront = new Ray(front.position, front.forward);
        Debug.DrawRay(front.position, front.forward * 20f, Color.green);

        if(Physics.Raycast(rayFront, out hitFront, 20f))
        {

            if(hitFront.collider.tag == "Environment")
            {
                float distF = Vector3.Distance(front.position, hitFront.point);
                Debug.Log("distance front is " + distF);

                if (distF <= 8f && _tpmScript.touchpad.y > -0.5f)
                {
                    _tpmScript.speed = 0f;
                    _tpmScript.touchpad = new Vector2(0f, 0f);
                }
                else
                {
                    _tpmScript.speed = 5f;
                }

              
            }
            
        }


        RaycastHit hitBack;
        Ray rayBack = new Ray(back.position, (-back.forward));
        Debug.DrawRay(back.position, (-front.forward) * 20f, Color.green);

        if (Physics.Raycast(rayBack, out hitBack, 20f))
        {

            if (hitBack.collider.tag == "Environment")
            {
                float distB = Vector3.Distance(back.position, hitBack.point);
                Debug.Log("distance back is " + distB);

                if (distB <= 8f && _tpmScript.touchpad.y < -0.5f)
                {
                    _tpmScript.speed = 0f;
                    _tpmScript.touchpad = new Vector2(0f, 0f);
                }
                else
                {
                    _tpmScript.speed = 5f;
                }


            }

        }

    }
}
