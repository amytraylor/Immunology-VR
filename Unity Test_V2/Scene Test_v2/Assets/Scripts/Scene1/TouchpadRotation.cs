using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class TouchpadRotation : MonoBehaviour
{

    public GameObject player;
    public float sensitivityX = 1.5f;
    //public Material mUnlit;
    //public Material mLit;

    SteamVR_Controller.Device device;
    SteamVR_TrackedObject controller;

    Vector2 touchpad;

    /* private void Awake()
     {

         rR = indicatorR.GetComponent<Renderer>();
         rL = indicatorL.GetComponent<Renderer>();
     }*/

    void Start()
    {
        controller = gameObject.GetComponent<SteamVR_TrackedObject>();


        // rR.material = mUnlit;
        //rL.material = mUnlit;
    }


    void FixedUpdate()
    {
        device = SteamVR_Controller.Input((int)controller.index);
        //If finger is on touchpad
        if (device.GetTouch(SteamVR_Controller.ButtonMask.Touchpad))
        {
            //Read the touchpad values
            touchpad = device.GetAxis(EVRButtonId.k_EButton_SteamVR_Touchpad);


            // handle rotation via touchpad
            if (touchpad.x > 0.5f || touchpad.x < -0.5f)
            {
                player.transform.Rotate(0, touchpad.x * sensitivityX, 0);
            }

            Debug.Log("Touchpad X = " + touchpad.x + " : Touchpad Y = " + touchpad.y);

            if (touchpad.y > 0.5f || touchpad.y < -0.5f)
            {
                player.transform.Rotate(touchpad.y * sensitivityX, 0, 0);
            }

        }
        
    }
}
