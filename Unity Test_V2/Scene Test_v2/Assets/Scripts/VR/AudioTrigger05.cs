using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioTrigger05 : MonoBehaviour {

    public bool playAudio05;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            playAudio05 = true;

            GetComponent<BoxCollider>().isTrigger = false;
        }
    }
}
