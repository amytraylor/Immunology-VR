using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class MoveOnNormals : MonoBehaviour {

    public GameObject player;
    public float speed;
    public float maxRotationDegree = 90f;
    public float positionOffsetY;
    public float sensitivityX = 0.3f;

    // Get animator component
    public GameObject cockPit;
    private Animator anim;

    SteamVR_Controller.Device device;
    SteamVR_TrackedObject controller;

    Vector2 touchpad;
    
    private Vector3 playerPos;


    // Use this for initialization
    void Start () {
        controller = gameObject.GetComponent<SteamVR_TrackedObject>();
        anim = cockPit.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        RaycastHit hit;
        Ray downRay = new Ray(player.transform.position, -player.transform.up);

        Debug.DrawRay(player.transform.position, (-player.transform.up) * 50, Color.red);

        if (Physics.Raycast(downRay, out hit, 50f))
        {
            Vector3 hitNormal = hit.normal;
            Vector3 hitPosition = hit.point;

            Debug.DrawRay(hitPosition, hitNormal * 10, Color.green);

            Quaternion targetRotation = Quaternion.FromToRotation(Vector3.up, hitNormal);
            Quaternion finalRotation = Quaternion.RotateTowards(player.transform.rotation, targetRotation, maxRotationDegree * Time.deltaTime);

            //player.transform.rotation = Quaternion.Euler(finalRotation.eulerAngles.x, 0, 0);
            player.transform.rotation = finalRotation;
            //player.transform.up = hitNormal;
            player.transform.position = hitPosition + player.transform.up * positionOffsetY;

        }



        device = SteamVR_Controller.Input((int)controller.index);
        //If finger is on touchpad
        if (device.GetTouch(SteamVR_Controller.ButtonMask.Touchpad))
        {
            touchpad = device.GetAxis(EVRButtonId.k_EButton_SteamVR_Touchpad);

            if (touchpad.y > 0.5f)
            {
                // Move Forward
                player.transform.position += player.transform.forward * Time.deltaTime * (touchpad.y * speed);
                anim.SetBool("isForward", true);

            }
            else
            {
                //rF.material = mUnlit;
                anim.SetBool("isForward", false);
            }



            if (touchpad.y < -0.5f)
            {
                // Move Back
                player.transform.position += player.transform.forward * Time.deltaTime * (touchpad.y * speed);
                anim.SetBool("isBack", true);
            }
            else
            {
                //rB.material = mUnlit;
                anim.SetBool("isBack", false);
            }


            // Rotation: yaw
            if (touchpad.x > 0.5f)
            {
                player.transform.Rotate(0, touchpad.x * sensitivityX, 0);
                anim.SetBool("isRight", true);
            }
            else
            {
                //rR.material = mUnlit;
                anim.SetBool("isRight", false);
            }



            if (touchpad.x < -0.5f)
            {
                player.transform.Rotate(0, touchpad.x * sensitivityX, 0);
                anim.SetBool("isLeft", true);
            }
            else
            {
                //rL.material = mUnlit;
                anim.SetBool("isLeft", false);
            }



        }
        else
        {
            if (!device.GetTouch(SteamVR_Controller.ButtonMask.Touchpad))
                anim.SetBool("isForward", false);
            anim.SetBool("isBack", false);
            anim.SetBool("isLeft", false);
            anim.SetBool("isRight", false);
        }

    }
}
