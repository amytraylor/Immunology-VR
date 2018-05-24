using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SWS;
using TMPro;

public class StartGame : MonoBehaviour {

    public GameObject logo;
    private Animator animLogo;
    private splineMove _splineMove;
    private splineMove _splineMoveFront;
    private splineMove _splineMoveBack;
    private splineMove _splineMoveSide;
    public GameObject player;
    public GameObject frontCells;
    public GameObject backCells;
    public GameObject sideCells;
    public GameObject startText;
    private TextMeshPro t_script;
    bool isHit;
    public TimerCountdown timerScript;
    public PlayerHealth pHealthScript;
    public AudioManager audioManagerScript;

    //private bool isStart;


    //vive controller tracking and input
    private SteamVR_TrackedObject controller;
    private SteamVR_Controller.Device device
    {
        get { return SteamVR_Controller.Input((int)controller.index); }
    }

    void Awake()
    {
        animLogo = logo.GetComponent<Animator>();
        controller = GetComponent<SteamVR_TrackedObject>();
        _splineMove = player.GetComponent<splineMove>();

        _splineMoveFront = frontCells.GetComponent<splineMove>();
        _splineMoveBack = backCells.GetComponent<splineMove>();
        _splineMoveSide = sideCells.GetComponent<splineMove>();

        //isStart = _splineMove.onStart;
        t_script = startText.GetComponent<TextMeshPro>();

    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (device.GetHairTrigger())
        {
            RaycastHit hit;
            if (Physics.Raycast(controller.transform.position, controller.transform.forward, out hit))
            {
                if(hit.collider.tag == "Start")
                {
                    t_script.color = Color.green;
                    isHit = true;
                }
                else
                {
                    t_script.color = new Color32(0, 143, 255, 255);
                    isHit = false;
                }

            }

        }
        else
        {
            t_script.color = new Color32(0, 143, 255, 255); ;
            
        }


        if (device.GetHairTriggerUp() && isHit && !audioManagerScript.isStartLocked)
        {
            _splineMove.StartMove();

            _splineMoveFront.startPoint = 3;
            _splineMoveFront.StartMove();

            _splineMoveBack.StartMove();

            _splineMoveSide.startPoint = 2;
            _splineMoveSide.StartMove();

            t_script.color = Color.green;

            animLogo.SetTrigger("startMove");
            Destroy(logo, 3f);

            timerScript.isCountDownStart = true;
            pHealthScript.isStart = true;
        }

    }
}
