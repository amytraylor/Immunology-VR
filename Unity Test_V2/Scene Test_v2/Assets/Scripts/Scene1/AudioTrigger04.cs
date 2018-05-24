using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioTrigger04 : MonoBehaviour {

    public bool playAudio04;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            playAudio04 = true;
        }
    }
}
