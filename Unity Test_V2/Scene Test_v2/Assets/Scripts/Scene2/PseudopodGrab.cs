using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class PseudopodGrab : MonoBehaviour
{

    public GameObject pseudopod;
    public float speed;
    public float alignSpeed;
    public GameObject player;
    public GameObject grabProb;
    public LineRenderer lineAlignAid;

    private Vector2 touchPad;
    private OnCollisionWithPathogens _scriptOCWP;
    private float releaseDist;
    private GameObject bacteria;

    //vive controller tracking and input
    public SteamVR_TrackedObject controller;
    private SteamVR_Controller.Device device
    {
        get { return SteamVR_Controller.Input((int)controller.index); }
    }


    private void Awake()
    {
        controller = GetComponent<SteamVR_TrackedObject>();
        _scriptOCWP = grabProb.GetComponent<OnCollisionWithPathogens>();
        bacteria = null;
    }


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (device.GetTouch(SteamVR_Controller.ButtonMask.Touchpad))
        {
            touchPad = device.GetAxis(EVRButtonId.k_EButton_SteamVR_Touchpad);

            if (touchPad.y > 0f)
            {
                Vector3 offset = new Vector3(0f, 0f, 0.5f);
                pseudopod.transform.localScale = new Vector3(pseudopod.transform.localScale.x, pseudopod.transform.localScale.y, touchPad.y * speed);
                grabProb.transform.position = (pseudopod.transform.forward.normalized) * touchPad.y * (speed-0f) + pseudopod.transform.position;
            }

            /*if(touchPad.y > 0f || touchPad.y < 0f)
            {
                grabProb.transform.position += player.transform.forward * Time.deltaTime * (touchPad.y * 5f);
            }*/
        }

        if (device.GetHairTrigger() && !_scriptOCWP.isColliding)
        {
            
            RaycastHit hit;
            if (Physics.Raycast(controller.transform.position, controller.transform.forward, out hit))
            {
                lineAlignAid.enabled = true;
                lineAlignAid.SetPosition(0, controller.transform.position);
                lineAlignAid.SetPosition(1, hit.point);

                bacteria = hit.collider.gameObject;
                Vector3 hitObjectCenter = hit.collider.bounds.center;
                Vector3 tempPosPlayer = player.transform.position;
                tempPosPlayer.y = hitObjectCenter.y + 3f;
                //tempPosPlayer.z = tempPosPlayer.z - 5f;
                player.transform.position += (tempPosPlayer - player.transform.position).normalized * alignSpeed;


    
            }

           
        }
        else
        {
            lineAlignAid.enabled = false;
            bacteria = null;
        }

        releaseGrab();

    }


    void releaseGrab()
    {
        releaseDist = Vector3.Distance(player.transform.position, _scriptOCWP.target.transform.position);
        Debug.Log("releaseDist is " + releaseDist);

        if(releaseDist <= 3f)
        {
            _scriptOCWP.target.transform.parent = null;

            _scriptOCWP.isColliding = false;

            //Vector3 tempPos = player.transform.position;
            //tempPos.y = tempPos.y - 5f;
            //tempPos.z = tempPos.z - 3f;
            //bacteria.transform.position = tempPos;
        }
    }
}
