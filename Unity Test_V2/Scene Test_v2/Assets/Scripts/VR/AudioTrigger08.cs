using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioTrigger08 : MonoBehaviour {

    public bool playAudio08;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            playAudio08 = true;

            GetComponent<BoxCollider>().isTrigger = false;
        }
    }
}
