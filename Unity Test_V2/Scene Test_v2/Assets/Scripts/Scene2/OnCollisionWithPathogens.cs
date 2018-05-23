using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnCollisionWithPathogens : MonoBehaviour {

    public bool isColliding;
    public GameObject target;

    private void Awake()
    {
        target = null;
    }
    void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.tag == "Bacteria")
        {
            isColliding = true;
            target = other.gameObject;

            other.gameObject.transform.parent = transform;
            Destroy(other.gameObject.GetComponent<Rotate>());
            Destroy(other.gameObject.GetComponent<Animation>());
            target.transform.localScale = target.transform.localScale * 0.5f;
            
        }
        
    }
}
