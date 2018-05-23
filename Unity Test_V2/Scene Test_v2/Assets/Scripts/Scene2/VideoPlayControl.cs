using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoPlayControl : MonoBehaviour {

    VideoPlayer videoplayer;
    public VideoClip[] videoClips;
    public GameObject screen;
    public GameObject leftController;
    WeaponShift weaponScript;

    private void Awake()
    {
        videoplayer = GetComponent<VideoPlayer>();
        screen.SetActive(false);
        weaponScript = leftController.GetComponent<WeaponShift>();
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
        if(weaponScript.isParticle)
        {
            screen.SetActive(true);
            videoplayer.clip = videoClips[0];
            videoplayer.Play();

        }
        


        if (weaponScript.isIngest)
        {
            screen.SetActive(true);
            videoplayer.clip = videoClips[1];
            videoplayer.Play();

        }
        

        if (weaponScript.isNETS)
        {
            screen.SetActive(true);
            videoplayer.clip = videoClips[2];
            videoplayer.Play();

        }
        
    }
}
