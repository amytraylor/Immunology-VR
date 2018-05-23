using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateTrigger5 : MonoBehaviour {

    public GameObject state5Prefab;
    public GameObject pivot;
    public GameObject explosionPrefab;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Bacteria State 4")
        {

            Vector3 posState5 = other.gameObject.transform.position;

            GameObject s5 = Instantiate(state5Prefab, posState5, other.gameObject.transform.rotation);
            //other.gameObject.SetActive(false);
            GameObject litTransition = Instantiate(explosionPrefab, posState5, transform.rotation);

            s5.transform.parent = pivot.transform;
            s5.transform.localScale = other.gameObject.transform.localScale * 0.9f;

            Destroy(other.gameObject);
            Destroy(litTransition, 2f);
        }
    }
}
