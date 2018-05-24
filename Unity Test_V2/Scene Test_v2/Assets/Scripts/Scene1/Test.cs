using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChemoSensorAudio : MonoBehaviour {

    private float gapToNext;
    //private int safetyCounter;
    public AudioSource oneBeep;
    public Transform chemokine;
    public GameObject sensor;
    public float range;
    private float dist;
    private float distFactor;

   

    void Start()
    {

        ExcitingCountdown();
        
    }

    void Update()
    {
        dist = Vector3.Distance(chemokine.position, transform.position);
        distFactor = dist / range;

    }


    private void ExcitingCountdown()
    {

        gapToNext = 1f;
        //safetyCounter = 30;
        PlayOneStep();
    }

    private void PlayOneStep()
    {

        
            oneBeep.Play();

            gapToNext = gapToNext * distFactor;
          
            //Debug.Log("gap is now " + gapToNext.ToString("f4"));

            Invoke("ExcitingCountdown", gapToNext);
       
        
    }
}
