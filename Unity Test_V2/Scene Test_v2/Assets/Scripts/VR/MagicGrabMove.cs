using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicGrabMove : MonoBehaviour
{

    public GameObject player;
    private Vector3 target;

    private Vector3 prevPos;
    private Vector3 curPos;

    public bool canGrab;

    //vive controller tracking and input
    public SteamVR_TrackedObject controller;
    private SteamVR_Controller.Device device
    {
        get { return SteamVR_Controller.Input((int)controller.index); }
    }

    public LineRenderer line;


    void Awake()
    {

        controller = GetComponent<SteamVR_TrackedObject>();

    }

    void Start()
    {

        prevPos = curPos;
    }


    void Update()
    {
        if (device.GetHairTrigger())
        {
            RaycastHit hit;
            if (Physics.Raycast(controller.transform.position, controller.transform.forward, out hit))
            {
                line.enabled = true;

                target = hit.point;

                line.SetPosition(0, controller.transform.position);
                line.SetPosition(1, target);

                canGrab = true;
                //player.transform.position += (target - controller.transform.position).normalized * 0.05f;
                curPos = controller.transform.localPosition;



                player.transform.position += (prevPos - curPos) * 10f;

                prevPos = curPos;

            }
            else
            {
                canGrab = false;
            }


        }
        else
        {
            line.enabled = false;
        }
    }
}
