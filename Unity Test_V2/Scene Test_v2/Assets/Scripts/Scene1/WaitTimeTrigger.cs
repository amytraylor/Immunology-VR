using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitTimeTrigger : MonoBehaviour {

    
    private float passedTime;
    private float triggerTime;
    public bool startCountTime;
    public float waitTime;
    public ParticleSystem particle;
    public Light pointLight;



	// Use this for initialization
	void Start () {
                
	}
	
	// Update is called once per frame
	void Update () {
        if (startCountTime)
        {
            passedTime = Time.time - triggerTime;
            Debug.Log("Elapsed time is: " + passedTime.ToString("F1"));
            
        }

        if(passedTime >= waitTime)
        {
            pointLight.intensity = 3f;
            particle.Play();

        }
	}

    private void OnTriggerEnter(Collider other)
    {
        triggerTime = Time.time;
        Debug.Log("Trigger time is: " + triggerTime.ToString("F1"));
        
        startCountTime = true;
    }
}
