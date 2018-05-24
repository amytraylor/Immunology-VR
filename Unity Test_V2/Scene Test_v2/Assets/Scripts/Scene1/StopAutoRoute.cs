using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SWS;

public class StopAutoRoute : MonoBehaviour {

    public GameObject player;
   
    public GameObject leftController;

    private splineMove splineMoveScript;
    private TouchpadMove touchpadMoveScript;

    private void Awake ()
    {
        splineMoveScript = player.GetComponent<splineMove>();
        touchpadMoveScript = leftController.GetComponent<TouchpadMove>();
    } 

	
    void OnTriggerEnter(Collider other)
    {
        if (splineMoveScript.enabled)
        {
            splineMoveScript.enabled = false;
            
            Debug.Log("trigger entered");
        }

        touchpadMoveScript.enabled = true;

        
    }

    void OnTriggerExit(Collider other)
    {
        if (!splineMoveScript.enabled)
        {
            return;
        }

        //Debug.Log("trigger exit");
    }
}
