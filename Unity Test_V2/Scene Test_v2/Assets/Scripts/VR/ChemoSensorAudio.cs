using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour {

    private float gapToNext;
    public AudioSource oneBeep;
    public Transform chemokine;
    public GameObject sensor;
    public float range;
    private float dist;
    private float distFactor;

   

    void Start()
    {
        ApproachingChemokine();
    }


    void Update()
    {
        dist = Vector3.Distance(chemokine.position, transform.position);
        distFactor = dist / range;

    }


    private void ApproachingChemokine()
    {
        gapToNext = 1f;
        PlaySound();
    }


    private void PlaySound()
    {
            oneBeep.Play();

            gapToNext = gapToNext * distFactor;
            
            Invoke("ApproachingChemokine", gapToNext+0.2f);
    }
}
