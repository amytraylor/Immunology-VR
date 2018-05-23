using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class MagicMoveTouchpad : MonoBehaviour {

    public GameObject player;
    public float speed;
    public GameObject sphere;
    public float turningRate;
    private Vector3 target;
    public bool isMoving;
    private Vector2 touchpad;

    //create a list of hitpoints
    private List<Vector3> hitPoints = new List<Vector3>();

    public Transform endPoint;
    //private Vector3 startPoint;

    //vive controller tracking and input
    public SteamVR_TrackedObject controller;
    private SteamVR_Controller.Device device
    {
        get { return SteamVR_Controller.Input((int)controller.index); }
    }

    public LineRenderer lineHit;
    //public LineRenderer lineEmpty;


    void Awake()
    {

        controller = GetComponent<SteamVR_TrackedObject>();
        sphere.SetActive(false);

    }

    void Start()
    {
        //speed = 0.05f;
    }


    void Update()
    {
        //test hitPoint list method
        if (device.GetHairTrigger())
        {
            RaycastHit hit;
            if (Physics.Raycast(controller.transform.position, controller.transform.forward, out hit))
            {
                lineHit.enabled = true;
                //lineEmpty.enabled = false;

                hitPoints.Add(hit.point);
                target = hitPoints[0];
                Debug.DrawRay(controller.transform.position, controller.transform.forward * 500f, Color.red);
                Debug.Log(hitPoints.Count);

                lineHit.SetPosition(0, controller.transform.position);
                lineHit.SetPosition(1, target);

                sphere.SetActive(true);
                sphere.transform.position = target;

                Quaternion r = Quaternion.LookRotation(target - player.transform.position);
                Quaternion r2 = Quaternion.Euler(player.transform.rotation.x, r.eulerAngles.y, player.transform.rotation.z);
                player.transform.rotation = Quaternion.RotateTowards(player.transform.rotation, r2, turningRate * Time.deltaTime);

                if (player.transform.rotation == r2)
                {
                    isMoving = true;
                }

                if (isMoving && device.GetTouch(SteamVR_Controller.ButtonMask.Touchpad))
                {
                    touchpad = device.GetAxis(EVRButtonId.k_EButton_SteamVR_Touchpad);

                    if (touchpad.y >= 0.5f || touchpad.y <= -0.5f)
                    {
                        player.transform.position += (target - controller.transform.position).normalized * (touchpad.y * speed);
                    }
                }

            }
            /*else if (device.GetHairTrigger() && !lineHit.enabled)
            {
                lineEmpty.enabled = true;

                lineEmpty.SetPosition(0, controller.transform.position);
                lineEmpty.SetPosition(1, endPoint.position);

                lineEmpty.material.mainTextureOffset = new Vector2(lineEmpty.material.mainTextureOffset.x - Random.Range(-0.01f, 0.05f), 0f);
            }*/

        }
        else
        {
            lineHit.enabled = false;
            //lineEmpty.enabled = false;
            sphere.SetActive(false);
            isMoving = false;
            hitPoints.Clear();

        }
    }
}
