using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectinStopAnimation : MonoBehaviour
{

    private Animation anim;
    private Animator anim_cockpit;
    //private Collider col;
    public GameObject player;
    //private bool isTriggered;

    void Awake()
    {
        anim = GetComponent<Animation>();
        //col = GetComponent<BoxCollider>();
        anim_cockpit = player.GetComponent<Animator>();
    }

    

    void OnTriggerEnter(Collider other)
    {
        /*if(isTriggered == false)
        {
            anim_cockpit.SetBool("isHit", true);
            isTriggered = true;
        }*/
        anim.Stop();
        //col.isTrigger = false;
        //anim_cockpit.SetBool("isHit", false);

    }

    

    void OnTriggerExit(Collider other)
    {
        anim.Play();
        //isTriggered = true;
    }

}
