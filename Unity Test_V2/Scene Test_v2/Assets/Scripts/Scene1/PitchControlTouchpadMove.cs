using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class PitchControlTouchpadMove : MonoBehaviour {

    public GameObject player;
    public float sensitivityRot;

    Vector2 touchPad;
    

    //vive controller tracking and input
    public SteamVR_TrackedObject controller;
    private SteamVR_Controller.Device device
    {
        get { return SteamVR_Controller.Input((int)controller.index); }
    }


    private void Awake()
    {
        controller = GetComponent<SteamVR_TrackedObject>();
    }
    
	
	// Update is called once per frame
	void Update () {

        //touchpad control pitch and yaw of neutrophil body
        if (device.GetPress(SteamVR_Controller.ButtonMask.Touchpad))
        {
            
            touchPad = device.GetAxis(EVRButtonId.k_EButton_SteamVR_Touchpad);

            
            if (touchPad.y > 0.5f || touchPad.y < -0.5f)
            {
                player.transform.Rotate(touchPad.y * sensitivityRot, 0, 0);
            }
        }

    }
}
