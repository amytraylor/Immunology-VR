using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateTrigger3 : MonoBehaviour {

    //public GameObject storageScale;
    public GameObject state3Prefab;
    public GameObject pivot;
    public GameObject explosionPrefab;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Bacteria State 2")
        {

            Vector3 posState3 = other.gameObject.transform.position;

            GameObject s3 = Instantiate(state3Prefab, posState3, other.gameObject.transform.rotation);
            //other.gameObject.SetActive(false);
            GameObject litTransition = Instantiate(explosionPrefab, posState3, transform.rotation);

            s3.transform.parent = pivot.transform;
            s3.transform.localScale = other.gameObject.transform.localScale * 0.9f;

            Destroy(other.gameObject);
            Destroy(litTransition, 2f);
        }
    }
}
