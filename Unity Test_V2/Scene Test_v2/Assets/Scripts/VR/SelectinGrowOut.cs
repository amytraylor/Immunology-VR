using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectinGrowOut : MonoBehaviour {

    public GameObject selectins;
    public GameObject selectin15;
    private Animator anim;
    private Animation anim15;


    private void Awake()
    {
        anim = selectins.GetComponent<Animator>();
        anim15 = selectin15.GetComponent<Animation>();
    }

    private void OnTriggerEnter(Collider other)
    {
        anim.SetBool("isOut", true);
        anim15.Stop();
    }

    private void OnTriggerExit(Collider other)
    {
        anim15.Play();
    }
}
