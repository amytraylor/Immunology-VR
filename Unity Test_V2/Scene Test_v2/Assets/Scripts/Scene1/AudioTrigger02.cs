using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioTrigger02 : MonoBehaviour
{

    public bool playAudio02;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            playAudio02 = true;
        }
    }
}