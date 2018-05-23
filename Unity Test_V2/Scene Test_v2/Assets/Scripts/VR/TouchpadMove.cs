using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class TouchpadMove : MonoBehaviour
{

    public GameObject player;
    public float speed;
    public float sensitivityX = 0.3f;
    
    // Get move direction indicator materials
    public Material mUnlit;
    public Material mLit;
    public Material mLit2;
    public GameObject indicatorF;
    public GameObject indicatorB;
    public GameObject indicatorR;
    public GameObject indicatorL;
    private Renderer rF;
    private Renderer rB;
    private Renderer rR;
    private Renderer rL;

    // Get animator component
    public GameObject cockPit;
    private Animator anim;


    // Controller tracked object setup
    SteamVR_Controller.Device device;
    SteamVR_TrackedObject controller;

    public Vector2 touchpad;

    private Vector3 playerPos;

    
    private void Awake()
    {
        rF = indicatorF.GetComponent<Renderer>();
        rB = indicatorB.GetComponent<Renderer>();
        rR = indicatorR.GetComponent<Renderer>();
        rL = indicatorL.GetComponent<Renderer>();
    }

    void Start()
    {
        controller = gameObject.GetComponent<SteamVR_TrackedObject>();

        rF.material = mUnlit;
        rB.material = mUnlit;
        rR.material = mUnlit;
        rL.material = mUnlit;

        anim = cockPit.GetComponent<Animator>();

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        device = SteamVR_Controller.Input((int)controller.index);
        //If finger is on touchpad
        if (device.GetTouch(SteamVR_Controller.ButtonMask.Touchpad))
        {
            //Read the touchpad values
            touchpad = device.GetAxis(EVRButtonId.k_EButton_SteamVR_Touchpad);

            //AlignToSurface();
            AlignToSurfaceDoubleRay();

            // Handle movement via touchpad
            if (touchpad.y > 0.5f)
            {
                // Move Forward
                player.transform.position += player.transform.forward * Time.deltaTime * (touchpad.y * speed);
                rF.material = mLit;

                //Forward animation
                anim.SetBool("isForward", true);
                //shell.transform.Rotate(touchpad.y*speed, 0, 0);

            }
            else
            {
                rF.material = mUnlit;
                anim.SetBool("isForward", false);
            }


            if (touchpad.y < -0.5f)
            {
                // Move Back
                player.transform.position += player.transform.forward * Time.deltaTime * (touchpad.y * speed);
                rB.material = mLit;

                //Back animation
                anim.SetBool("isBack", true);
                //shell.transform.Rotate(touchpad.y * speed, 0, 0);
            }
            else
            {
                rB.material = mUnlit;
                anim.SetBool("isBack", false);
            }

            // Rotation: yaw
            if (touchpad.x > 0.5f)
            {
                player.transform.Rotate(0, touchpad.x * sensitivityX, 0);
                rR.material = mLit2;
                anim.SetBool("isRight", true);
            }
            else
            {
                rR.material = mUnlit;
                anim.SetBool("isRight", false);
            }


            if (touchpad.x < -0.5f)
            {
                player.transform.Rotate(0, touchpad.x * sensitivityX, 0);
                rL.material = mLit2;
                anim.SetBool("isLeft", true);
            }
            else
            {
                rL.material = mUnlit;
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

            rF.material = mUnlit;
            rB.material = mUnlit;
            rL.material = mUnlit;
            rR.material = mUnlit;
        }
        
    }


    // Raycast to check surface hight
    /*void AlignToSurface()
    {
        RaycastHit hit;

        Ray rayDown = new Ray(player.transform.position, -Vector3.up);

        Debug.DrawRay(player.transform.position, -Vector3.up * 100, Color.red);

        if (Physics.Raycast(rayDown, out hit, 100f))
        {

            Vector3 hitPosition = hit.point;
            Vector3 temPos = player.transform.position;
            float offset = 8f;
            temPos.y = offset + hitPosition.y;
            player.transform.position = temPos;

            //Debug.Log(temPos.y);

            Quaternion targetRotation = Quaternion.FromToRotation(player.transform.up, hit.normal);
            Quaternion finalRotation = Quaternion.RotateTowards(player.transform.rotation, targetRotation, Time.deltaTime);
            //player.transform.rotation = Quaternion.Euler(finalRotation.eulerAngles.x, 0, 0);
            player.transform.rotation = finalRotation;

            Debug.Log(player.transform.rotation.x);
        }


    }*/


    void AlignToSurfaceDoubleRay()
    {
        RaycastHit hitFront;
        Vector3 transformForward = transform.forward;

        RaycastHit hitBack;
        Vector3 transformBack = -transform.forward;

        Ray rayDownFront = new Ray(player.transform.position + 5f*transformForward, -Vector3.up);
        Debug.DrawRay(player.transform.position + 5f * transformForward, -Vector3.up * 100, Color.red);

        Ray rayDownBack = new Ray(player.transform.position + 5f * transformBack, -Vector3.up);
        Debug.DrawRay(player.transform.position + 5f * transformBack, -Vector3.up * 100, Color.red);

        if (Physics.Raycast(rayDownFront, out hitFront, 100f) && Physics.Raycast(rayDownBack, out hitBack, 100f))
        {

            Vector3 hitInfoFront = hitFront.point;
            Vector3 hitInfoBack = hitBack.point;

            Vector3 averageHit = (hitInfoFront + hitInfoBack) / 2;
            Vector3 averageNormal = (hitFront.normal + hitBack.normal) / 2;

            Vector3 temPos = player.transform.position;
            float offset = 8f;
            temPos.y = offset + averageHit.y;
            player.transform.position = temPos;

            //Debug.DrawRay(averageHit, averageNormal * 100, Color.green);
            //Debug.Log(temPos.y);

            Quaternion targetRotation = Quaternion.FromToRotation(player.transform.up, averageNormal);
            Quaternion finalRotation = Quaternion.RotateTowards(player.transform.rotation, targetRotation, Time.deltaTime);
            //player.transform.rotation = Quaternion.Euler(finalRotation.eulerAngles.x, 0, 0);
            player.transform.rotation = finalRotation;

            //Debug.Log(player.transform.rotation.x);
        }


    }

}
