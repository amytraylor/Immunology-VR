using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioTrigger06 : MonoBehaviour {

    public bool playAudio06;
    public Text text;
  

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            playAudio06 = true;

            GetComponent<BoxCollider>().isTrigger = false;

            text.text = "[MISSION] Look for transmigration portal";
            text.horizontalOverflow = HorizontalWrapMode.Wrap;

        }
    }
}
