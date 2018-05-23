using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateTrigger4 : MonoBehaviour {

    public GameObject state4Prefab;
    public GameObject pivot;
    public GameObject explosionPrefab;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Bacteria State 3")
        {

            Vector3 posState4 = other.gameObject.transform.position;

            GameObject s4 = Instantiate(state4Prefab, posState4, other.gameObject.transform.rotation);
            //other.gameObject.SetActive(false);
            GameObject litTransition = Instantiate(explosionPrefab, posState4, transform.rotation);

            s4.transform.parent = pivot.transform;
            s4.transform.localScale = other.gameObject.transform.localScale * 0.9f;

            Destroy(other.gameObject);
            Destroy(litTransition, 2f);
        }
    }
}
