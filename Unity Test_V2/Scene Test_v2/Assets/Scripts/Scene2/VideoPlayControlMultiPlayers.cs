using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoPlayControlMultiPlayers : MonoBehaviour {

    public VideoPlayer videoplayer1;
    public VideoPlayer videoplayer2;
    public VideoPlayer videoplayer3;
    
    public GameObject screen1;
    public GameObject screen2;
    public GameObject screen3;

    public GameObject leftController;
    WeaponShift weaponScript;

    private void Awake()
    {
        //videoplayer = GetComponent<VideoPlayer>();
        screen1.SetActive(false);
        screen2.SetActive(false);
        screen3.SetActive(false);
        weaponScript = leftController.GetComponent<WeaponShift>();
    }
    

    // Update is called once per frame
    void Update()
    {

        if (weaponScript.isParticle)
        {
            screen1.SetActive(true);
            
            videoplayer1.Play();

        }
        else
        {
            screen2.SetActive(false);
            screen3.SetActive(false);
            videoplayer1.Stop();
        }



        if (weaponScript.isIngest)
        {
            screen2.SetActive(true);
            
            videoplayer2.Play();

        }
        else
        {
            screen1.SetActive(false);
            screen3.SetActive(false);
            videoplayer2.Stop();
        }


        if (weaponScript.isNETS)
        {
            screen3.SetActive(true);
            
            videoplayer3.Play();

        }
        else
        {
            screen1.SetActive(false);
            screen2.SetActive(false);
            videoplayer3.Stop();
        }

    }
}
