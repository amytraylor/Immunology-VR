using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicClimbMove : MonoBehaviour
{
    public GameObject player;
    public float speed;
    private Vector3 target;
    
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
        //speed = 0.05f;
    }

    
    void Update()
    {
        if (device.GetHairTrigger())
        {
            RaycastHit hit;
            if(Physics.Raycast(controller.transform.position, controller.transform.forward, out hit))
            {
                line.enabled = true;

                target = hit.point;
                

                line.SetPosition(0, controller.transform.position);
                line.SetPosition(1, target);

                player.transform.position += (target - controller.transform.position).normalized * speed;
            }


        }
        else
        {
            line.enabled = false;
        }
    }
}
