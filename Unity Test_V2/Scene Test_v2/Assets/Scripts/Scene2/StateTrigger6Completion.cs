using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateTrigger6Completion : MonoBehaviour {

    
    private void OnTriggerExit(Collider other)
    {

        if (other.gameObject.tag == "Bacteria State 5")
        {
            Destroy(other.gameObject);
        }

        if (other.gameObject.tag == "Capsule Storage")
        {
            Destroy(other.gameObject);
        }
    }
}
