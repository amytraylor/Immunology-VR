using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalLightIntensity : MonoBehaviour {

    //public GameObject ChemoHotspot;
    public GameObject player;
    public GameObject portal;
    private Light lit;
    private float dist;
    private float intensityIndex = 0.5f;


	// Use this for initialization
	void Start () {
        lit = portal.GetComponent<Light>(); 
	}
	
	// Update is called once per frame
	void Update () {

        dist = Vector3.Distance(player.transform.position, transform.position);

        if(dist <= 20f)
        {
            lit.intensity = intensityIndex / (dist*0.01f);

            if(lit.intensity >= 6.5f)
            {
                lit.intensity = 6.5f;
            }

            //Debug.Log("portal light intensity is " + lit.intensity);
        }
        else
        {
            lit.intensity = intensityIndex;
        }

	}
}
