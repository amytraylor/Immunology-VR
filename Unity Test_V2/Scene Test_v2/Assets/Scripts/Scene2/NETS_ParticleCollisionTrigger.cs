using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NETS_ParticleCollisionTrigger : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Bacteria")
        {
            GameObject target = other.gameObject;
            
            target.GetComponent<EnemyHealth>().GotHit();
        }

        if (other.gameObject.tag == "Bacteria Sausage")
        {
            GameObject target = other.gameObject;

            target.transform.parent.GetComponent<EnemyHealthSausageBacteria>().GotHit();
        }

        if (other.gameObject.tag == "Bacteria Bighead")
        {
            GameObject target = other.gameObject;

            target.GetComponent<EnemyHealthSausageBacteria>().GotHit();
        }
    }
}
