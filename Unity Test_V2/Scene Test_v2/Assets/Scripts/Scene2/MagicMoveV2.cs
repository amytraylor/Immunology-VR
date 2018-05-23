using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicMoveV2 : MonoBehaviour
{

    public GameObject player;
    public float speed;
    public GameObject sphere;
    public float turningRate;
    private Vector3 target;
    public bool isMoving;
    public GameObject lineR; // create a reference to linerenderer on an empty gameobject in right controller
    private BoxCollider boxCol; // box collider on the linerenderer

    //create a list of hitpoints
    private List<Vector3> hitPoints = new List<Vector3>();

    public Transform endPoint;
    private float dist;
    //private float distHit;
    //private float counter = 0f;
    Vector3 pointA;
    public bool lengthLimit;
    private float x = 0f;
    //private float y = 0f;

    //vive controller tracking and input
    public SteamVR_TrackedObject controller;
    private SteamVR_Controller.Device device
    {
        get { return SteamVR_Controller.Input((int)controller.index); }
    }

    public LineRenderer lineHit;
    public LineRenderer lineEmpty;


    void Awake()
    {

        controller = GetComponent<SteamVR_TrackedObject>();
        sphere.SetActive(false);
        boxCol = lineR.GetComponent<BoxCollider>(); 
    }

    void Start()
    {


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
                lineEmpty.enabled = false;

                hitPoints.Add(hit.point);
                target = hitPoints[0];
                Debug.DrawRay(controller.transform.position, controller.transform.forward * 500f, Color.red);
                Debug.Log(hitPoints.Count);

                //distHit = Vector3.Distance(target, controller.transform.position);
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

                if (isMoving)
                {
                    player.transform.position += (target - controller.transform.position).normalized * speed;
                }

            }
            else if (device.GetHairTrigger() && !lineHit.enabled)
            {
                lineEmpty.enabled = true;

                lineEmpty.SetPosition(0, controller.transform.position);

                lineEmpty.material.mainTextureOffset = new Vector2(lineEmpty.material.mainTextureOffset.x - Random.Range(-0.01f, 0.05f), 0f);

                if (x < 30f && !lengthLimit)
                {
                    x += .2f;
                    pointA = controller.transform.position;
                    Vector3 pointAlongLine = x * controller.transform.forward + pointA;

                    dist = Vector3.Distance(controller.transform.position, pointAlongLine);

                    if (dist > 30f)
                    {
                        lengthLimit = true;
                        x = 30f;
                    }

                    
                    Vector3 colCenter = x * controller.transform.forward / 2 + pointA;

                    //boxCol.size = new Vector3(0.02f, 0.02f, x/2); // change box collider's size in accordance with line renderer length
                    //boxCol.center = new Vector3(boxCol.center.x, boxCol.center.y, pointAlongLine.z); // calculate center of box collider
                    //boxCol.transform.LookAt(pointAlongLine);
                   
                
                    lineEmpty.SetPosition(1, pointAlongLine);
                    endPoint.transform.position = pointAlongLine;
                    
                    //Debug.Log("the distance is " + dist);

                }

                if (x <= 30f && lengthLimit)
                {
                    x -= .5f;
                    if (x < 0f)
                    {
                        x = 0f;
                    }
                    Vector3 pointAlongLineBack = x * controller.transform.forward + pointA;
                    dist = Vector3.Distance(controller.transform.position, pointAlongLineBack);


                    endPoint.transform.position = pointAlongLineBack;
                   lineEmpty.SetPosition(1, pointAlongLineBack);

                    Vector3 colCenterBack = x * controller.transform.forward / 2 + pointA;
                    

                    //Debug.Log("x value is " + x);

                    //boxCol.size = new Vector3(0.02f, 0.02f, x/2); // change box collider's size in accordance with line renderer length
                    //boxCol.center = new Vector3(boxCol.center.x, boxCol.center.y, pointAlongLineBack.z);
                    //boxCol.transform.LookAt(pointAlongLineBack);

                }

            }

        }
        else
        {
            lineHit.enabled = false;
            lineEmpty.enabled = false;
            sphere.SetActive(false);
            isMoving = false;
            hitPoints.Clear();
            lengthLimit = false;
            x = 0f;

            //boxCol.size = new Vector3(0.02f, 0.02f, 1.02f);
            //boxCol.center = new Vector3(0f,0f,0.51f);
            endPoint.transform.position = new Vector3(0f, 0f, 0f);

        }
    }
}




//old codes
/*if (device.GetHairTriggerDown())
            {
                RaycastHit hit;
                if (Physics.Raycast(controller.transform.position, controller.transform.forward, out hit))
                {
                    lineHit.enabled = true;
                    lineEmpty.enabled = false;

                    Debug.DrawRay(controller.transform.position, controller.transform.forward * 50f, Color.red);
                    target = hit.point;

                    lineHit.SetPosition(0, controller.transform.position);
                    lineHit.SetPosition(1, target);


                    player.transform.position += (target - controller.transform.position).normalized * speed;

                    sphere.SetActive(true);
                    sphere.transform.position = target;


                }

            }
            else if (device.GetHairTrigger() && lineHit.enabled)
            {
                lineHit.SetPosition(0, controller.transform.position);

                Quaternion r = Quaternion.LookRotation(target - player.transform.position);
                Quaternion r2 = Quaternion.Euler(player.transform.rotation.x, r.eulerAngles.y, player.transform.rotation.z);
                player.transform.rotation = Quaternion.RotateTowards(player.transform.rotation, r2, turningRate*Time.deltaTime);

                if(player.transform.rotation == r2)
                {
                    isMoving = true;
                    //isTurning = false;
                }

                if (isMoving) {
                    player.transform.position += (target - controller.transform.position).normalized * speed;
                }

                lineEmpty.enabled = false;
            }
            else if (device.GetHairTrigger() && !lineHit.enabled)
            {
                lineEmpty.enabled = true;

                lineEmpty.SetPosition(0, controller.transform.position);
                lineEmpty.SetPosition(1, endPoint.position);

                lineEmpty.material.mainTextureOffset = new Vector2(lineEmpty.material.mainTextureOffset.x - Random.Range(-0.01f, 0.05f), 0f);
            }


            else
            {
                lineHit.enabled = false;
                lineEmpty.enabled = false;
                sphere.SetActive(false);
                isMoving = false;

            }*/
