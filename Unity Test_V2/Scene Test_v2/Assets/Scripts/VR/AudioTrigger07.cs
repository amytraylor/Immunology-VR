using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioTrigger07 : MonoBehaviour {

    public bool playAudio07;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            playAudio07 = true;

            GetComponent<BoxCollider>().isTrigger = false;
        }
    }
}
