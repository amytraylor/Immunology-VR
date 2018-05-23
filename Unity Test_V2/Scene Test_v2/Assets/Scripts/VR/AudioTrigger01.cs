using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioTrigger01 : MonoBehaviour {

    public bool playAudio01;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            playAudio01 = true;
        }
    }
}
