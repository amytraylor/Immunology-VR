using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class CapsulatedIngestion : MonoBehaviour
{

    public float alignSpeed;
    public GameObject player;
    public LineRenderer lineAlignAid;
    public LineRenderer lineEmpty;
    public Transform endPoint;
    public GameObject capsule;
    public GameObject carousel;
    public GameObject anchor;
    public GameObject carouselAssem;
    public float sensitivityRot;
    public GameObject storageScale;
    public GameObject bacteriaCapsulePrefeb;
    public GameObject state2Prefab;
    public GameObject state3Prefab;
    public GameObject state4Prefab;
    public GameObject state5Prefab;
    public ParticleSystem enzymeParticles1;
    public ParticleSystem enzymeParticles2;
    public ParticleSystem enzymeParticles3;
    public ParticleSystem enzymeParticles4;
    public ParticleSystem enzymeParticles5;

    private GameObject target;
    private float ingestDist;
    private float distOnHit;
    private Vector3 anchorOnHit;
    private Vector3 hitObjectCenter;
    private Vector3 tempPos;
    private float scaleDownRatio;
    private float scaleDifference;

    private Vector2 touchPad;
    private bool isScaledDown;
    private int counter;
    private GameObject indicator;
    private Renderer rend;

    private GameObject[] ingestedBacteria = new GameObject[6];
    private bool isState2;
    private bool isState3;
    private bool isState4;
    private bool isState5;
    private bool isState6;

    private GameObject state2;
    private GameObject state3;
    private GameObject state4;
    private GameObject state5;

    private Color32 deathColor = new Color32(255, 255, 255, 255);
    private SkinnedMeshRenderer bacteriaRend;

    //vive controller tracking and input
    public SteamVR_TrackedObject controller;
    private SteamVR_Controller.Device device
    {
        get { return SteamVR_Controller.Input((int)controller.index); }
    }


    private void Awake()
    {
        controller = GetComponent<SteamVR_TrackedObject>();
        capsule.SetActive(false);
        counter = 0;
        

    }


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {


        if (device.GetHairTriggerDown() && counter < 6)
        {

            RaycastHit hit;
            Debug.DrawRay(controller.transform.position, controller.transform.forward, Color.red);
            if (Physics.Raycast(controller.transform.position, controller.transform.forward, out hit, 20f))
            {
                if (hit.collider.tag == "Bacteria")
                {
                    lineAlignAid.enabled = true;
                    lineEmpty.enabled = false;

                    lineAlignAid.SetPosition(0, controller.transform.position);
                    lineAlignAid.SetPosition(1, hit.point);
               
                    target = hit.collider.gameObject;

                    hitObjectCenter = hit.collider.bounds.center;
                
                    //show a capsule surrounding selected bacteria
                    capsule.SetActive(true);
                    capsule.transform.position = hit.collider.bounds.center;
                    capsule.transform.localScale = hit.collider.bounds.size * 1.0f;

                    anchorOnHit = anchor.transform.position;
                    distOnHit = Vector3.Distance(target.transform.position, anchorOnHit);
                    Debug.Log("distOnHit is " + distOnHit);
                }

            }

        }

        else if (device.GetHairTrigger() && lineAlignAid.enabled && counter < 6)
        {

            
            lineAlignAid.SetPosition(0, controller.transform.position);

            //vertical alignment of player to bacteria
            Vector3 tempPosPlayer = player.transform.position;
            tempPosPlayer.y = hitObjectCenter.y + 5f;
            player.transform.position += (tempPosPlayer - player.transform.position).normalized * alignSpeed;

            //afte vertical alignment is done, player horizontal movement to bacteria
            if (Mathf.Abs(player.transform.position.y - tempPosPlayer.y) <= 0.05f)
            {
                tempPosPlayer.z = hitObjectCenter.z;
                tempPosPlayer.x = hitObjectCenter.x;

                player.transform.position += (tempPosPlayer - player.transform.position).normalized * alignSpeed;
            }

            //calculate distance between bacteria and an anchor point in player
            ingestDist = Vector3.Distance(target.transform.position, anchor.transform.position);
            //Debug.Log("Ingestion Dist is " + ingestDist);

            scaleDownRatio = 5f;
            scaleDifference = target.transform.localScale.sqrMagnitude - storageScale.transform.localScale.sqrMagnitude;

            if (scaleDifference > 0f && distOnHit > 1f && ingestDist > 2f)
            {
                target.transform.localScale -= (target.transform.localScale - storageScale.transform.localScale) / distOnHit * Time.deltaTime * scaleDownRatio;

                if(ingestDist <= 2f)
                {
                    target.transform.localScale = storageScale.transform.localScale;
                    scaleDownRatio = 0f;
                }

                Debug.Log("SCALE DIFFERENCE IS " + scaleDifference);

                
            }
              
            
            

            //if distance between the bacteria and the anchor is less than a set value, the bacteria will snap to the anchor
            if (ingestDist <= 2f && !isScaledDown && counter < 6)
            {
                
                
                target.transform.position = anchor.transform.position;
                //target.transform.localScale = storageScale.transform.localScale;  

                //Debug.Log("scale difference is " + (target.transform.localScale.sqrMagnitude - storageScale.transform.localScale.sqrMagnitude));

                //remove bacteria rotation scripts
                Rotate[] rScripts = target.GetComponents<Rotate>();
                foreach (Rotate r in rScripts)
                {
                    Destroy(r);
                }

                target.transform.rotation = storageScale.transform.rotation;

                

                capsule.SetActive(false);

                GameObject bacteriaCapsule = Instantiate(bacteriaCapsulePrefeb, anchor.transform.position, storageScale.transform.rotation);
                bacteriaCapsule.transform.localScale = target.transform.localScale * 1.2f;


                if (counter >= 1)
                {
                    carouselAssem.transform.Rotate(carouselAssem.transform.up, 60f);

                }
                
                target.transform.parent = carousel.transform;
                bacteriaCapsule.transform.parent = carousel.transform;

                Destroy(target.GetComponent<Animation>());

                ingestedBacteria[counter] = target;

                counter++;

                isScaledDown = true;

                
                Debug.Log("counter is " + counter);
            }


        }
        else
        {
            lineAlignAid.enabled = false;
            //capsule.SetActive(false);
            isScaledDown = false;
            distOnHit = 0f;
            
        }



        if (device.GetHairTrigger() && !lineAlignAid.enabled)
        {

            lineEmpty.enabled = true;
            lineEmpty.SetPosition(0, controller.transform.position);
            lineEmpty.SetPosition(1, endPoint.position);
        }
        else
        {
            lineEmpty.enabled = false;
        }


        //touchpad rotation control of cockpit
        if (device.GetPress(SteamVR_Controller.ButtonMask.Touchpad))
        {
            touchPad = device.GetAxis(EVRButtonId.k_EButton_SteamVR_Touchpad);

            if (touchPad.x > 0.5f || touchPad.x < -0.5f)
            {
                player.transform.Rotate(0, touchPad.x * sensitivityRot, 0);
            }


            if (touchPad.y > 0.5f || touchPad.y < -0.5f)
            {
                player.transform.Rotate(touchPad.y * sensitivityRot, 0, 0);
            }
        }


        //turn on carousel green indicator and change ingested bacteria states under influenece of enzymes
        if (counter == 1)
        {
            indicator = GameObject.FindGameObjectWithTag("Carousel Indicator 1");
            rend = indicator.GetComponent<Renderer>();
            rend.material.color = Color.green;

            enzymeParticles1.Play();
        }


        if (counter == 2)
        {
            indicator = GameObject.FindGameObjectWithTag("Carousel Indicator 2");
            rend = indicator.GetComponent<Renderer>();
            rend.material.color = Color.green;

            bacteriaRend = ingestedBacteria[0].GetComponentInChildren<SkinnedMeshRenderer>();
            bacteriaRend.material.color = deathColor;
            bacteriaRend.material.SetColor("_EmissionColor", Color.black);

            enzymeParticles2.Play();
        }


        if (counter == 3)
        {
            indicator = GameObject.FindGameObjectWithTag("Carousel Indicator 3");
            rend = indicator.GetComponent<Renderer>();
            rend.material.color = Color.green;


            bacteriaRend = ingestedBacteria[1].GetComponentInChildren<SkinnedMeshRenderer>();
            bacteriaRend.material.color = deathColor;
            bacteriaRend.material.SetColor("_EmissionColor", Color.black);


            if (!isState2)
            {
                state2 = Instantiate(state2Prefab, ingestedBacteria[0].transform.position, ingestedBacteria[0].transform.rotation);
                state2.transform.parent = carousel.transform;
                state2.transform.localScale = storageScale.transform.localScale * 90f;
                ingestedBacteria[0].SetActive(false);

                isState2 = true;

                
            }

            enzymeParticles3.Play();
        }


        if (counter == 4)
        {
            indicator = GameObject.FindGameObjectWithTag("Carousel Indicator 4");
            rend = indicator.GetComponent<Renderer>();
            rend.material.color = Color.green;

            bacteriaRend = ingestedBacteria[2].GetComponentInChildren<SkinnedMeshRenderer>();
            bacteriaRend.material.color = deathColor;
            bacteriaRend.material.SetColor("_EmissionColor", Color.black);


            if (!isState3)
            {

                state2.transform.position = ingestedBacteria[1].transform.position;
                ingestedBacteria[1].SetActive(false);

                state3 = Instantiate(state3Prefab, ingestedBacteria[0].transform.position, ingestedBacteria[0].transform.rotation);
                state3.transform.parent = carousel.transform;
                state3.transform.localScale = storageScale.transform.localScale * 90f;

                isState3 = true;

            }

            enzymeParticles4.Play();

        }

        if (counter == 5)
        {
            indicator = GameObject.FindGameObjectWithTag("Carousel Indicator 5");
            rend = indicator.GetComponent<Renderer>();
            rend.material.color = Color.green;

            bacteriaRend = ingestedBacteria[3].GetComponentInChildren<SkinnedMeshRenderer>();
            bacteriaRend.material.color = deathColor;
            bacteriaRend.material.SetColor("_EmissionColor", Color.black);

            if (!isState4)
            {

                state2.transform.position = ingestedBacteria[2].transform.position;
                ingestedBacteria[2].SetActive(false);

                state3.transform.position = ingestedBacteria[1].transform.position;

                state4 = Instantiate(state4Prefab, ingestedBacteria[0].transform.position, ingestedBacteria[0].transform.rotation);
                state4.transform.parent = carousel.transform;
                state4.transform.localScale = storageScale.transform.localScale * 90f;

                isState4 = true;
            }

            enzymeParticles5.Play();
        }

        if (counter == 6)
        {
            indicator = GameObject.FindGameObjectWithTag("Carousel Indicator 6");
            rend = indicator.GetComponent<Renderer>();
            rend.material.color = Color.green;

            bacteriaRend = ingestedBacteria[4].GetComponentInChildren<SkinnedMeshRenderer>();
            bacteriaRend.material.color = deathColor;
            bacteriaRend.material.SetColor("_EmissionColor", Color.black);


            if (!isState5)
            {

                state2.transform.position = ingestedBacteria[3].transform.position;
                ingestedBacteria[3].SetActive(false);

                state3.transform.position = ingestedBacteria[2].transform.position;

                state4.transform.position = ingestedBacteria[1].transform.position;

                state5 = Instantiate(state5Prefab, ingestedBacteria[0].transform.position, ingestedBacteria[0].transform.rotation);
                state5.transform.parent = carousel.transform;
                state5.transform.localScale = storageScale.transform.localScale * 90f;

                isState5 = true;
            }
        }

    }

    


    void CarouselRotation()
    {

    }

    

} 
