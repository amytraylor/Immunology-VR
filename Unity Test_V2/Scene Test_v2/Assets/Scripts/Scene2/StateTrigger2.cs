using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateTrigger2 : MonoBehaviour {

    //public GameObject storageScale;
    public GameObject state2Prefab;
    public GameObject pivot;
    public GameObject explosionPrefab;

    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Bacteria State 1")
        {
            
            Vector3 posState2 = other.gameObject.transform.position;

            GameObject s2 = Instantiate(state2Prefab, posState2, other.gameObject.transform.rotation);
            //other.gameObject.SetActive(false);
            GameObject litTransition = Instantiate(explosionPrefab, posState2, transform.rotation);

            s2.transform.parent = pivot.transform;
            s2.transform.localScale = other.gameObject.transform.localScale*0.9f;

            Destroy(other.gameObject);
            Destroy(litTransition, 2f);
           
        }
    }
}
