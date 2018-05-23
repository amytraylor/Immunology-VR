using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class ParticleLauncher : MonoBehaviour {

    public ParticleSystem particleLauncher;
    public GameObject player;
    
    private bool isON;



    //vive controller tracking and input
    public SteamVR_TrackedObject controller;
    private SteamVR_Controller.Device device
    {
        get { return SteamVR_Controller.Input((int)controller.index); }
    }


    private void Awake()
    {
        controller = GetComponent<SteamVR_TrackedObject>();
        
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (device.GetHairTrigger())
        {
            particleLauncher.Emit(1);
        }

        
    }

    private void OnParticleCollision(GameObject other)
    {
        if(other.transform.tag == "Bacteria")
        {
            Debug.Log("bacteria hit");
        }
    }
}
