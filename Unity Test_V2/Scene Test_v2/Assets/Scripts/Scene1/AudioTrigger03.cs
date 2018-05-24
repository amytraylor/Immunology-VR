using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioTrigger03 : MonoBehaviour {

    public bool playAudio03;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            playAudio03 = true;
        }
    }
}
