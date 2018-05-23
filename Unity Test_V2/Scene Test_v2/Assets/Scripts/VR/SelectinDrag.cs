using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SWS;

public class SelectinDrag : MonoBehaviour
{
    

    public GameObject player;
    private Animator anim;
    private splineMove splineMoveScript;
    //private bool isHit = false;
    private float speedAdjust;
    private AudioSource colSound;
    public AudioClip thump;
    public bool vibrate;



    // Use this for initialization
    void Start()
    {
        anim = player.GetComponent<Animator>();
        splineMoveScript = player.GetComponent<splineMove>();
        speedAdjust = splineMoveScript.speed;
        colSound = player.GetComponent<AudioSource>();
    }

    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Selectin")
        {
            anim.SetBool("isHit", true);
            speedAdjust -= 0.5f;
            splineMoveScript.ChangeSpeed(speedAdjust);
            colSound.PlayOneShot(thump, 1f);

            Debug.Log("hit!" + speedAdjust);

            vibrate = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Selectin")
        {
            anim.SetBool("isHit", false);

            vibrate = false;

        }
    }

    


    /*private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Selectin" && collision.rigidbody)
        {
            SpringJoint springJoint = gameObject.AddComponent<SpringJoint>();
            springJoint.connectedBody = collision.rigidbody;
            springJoint.breakForce = 50f;
            //springJoint.enableCollision = true;

            Debug.Log("hit!");


        }
    }*/

    /*private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Selectin")
        {
            Rigidbody rb = other.GetComponent<Rigidbody>();
            SpringJoint springJoint = gameObject.AddComponent<SpringJoint>();
            springJoint.connectedBody = rb;
            //springJoint.breakForce = 50f;
            //springJoint.enableCollision = true;
            rb.isKinematic = false;
            rb.useGravity = true;

            Debug.Log("hit!");
        }
    }*/

    /*void ReduceSpeed()
{
    if (isHit)
    {
        speed -= 1f * Time.deltaTime;

    }
}*/


}
