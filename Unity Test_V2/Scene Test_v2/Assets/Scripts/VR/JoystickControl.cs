using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickControl : MonoBehaviour {


    public GameObject controllerL;
    //public GameObject controllerR;

    public GameObject joystick;
    private Renderer rend;

    //public Material m0;
    //public Material m1;

    //private TouchpadMove touchpadMoveScript;
    private LaserPointer_Interact laserPointerScript;

    public GameObject cockPit;
    private Animator anim;

    void Awake()
    {
        //touchpadMoveScript = controllerL.GetComponent<TouchpadMove>();
        //touchpadMoveScript.enabled = false;

        laserPointerScript = controllerL.GetComponent<LaserPointer_Interact>();
        laserPointerScript.enabled = true;

        //rend = joystick.GetComponent<Renderer>();
        //rend.material = m0;
    }

    void Start()
    {
        anim = cockPit.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update () {

    }

    void OnTriggerEnter(Collider other)
    {
        //rend.material = m1;
        //touchpadMoveScript.enabled = true;
        laserPointerScript.enabled = false;
        Debug.Log("trigger entered");
    }

    void OnTriggerExit(Collider other)
    {
        //rend.material = m0;
        //touchpadMoveScript.enabled = false;
        laserPointerScript.enabled = true;
        Debug.Log("trigger exit");

        //Stop rolling animation
        anim.SetBool("isForward", false);
        anim.SetBool("isBack", false);
    }

}
