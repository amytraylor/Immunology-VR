using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngestingStateTrigger : MonoBehaviour {

    public bool isState1; // remove color
    public bool isState2;
    public bool isState3;
    public bool isState4;
    public bool isState5;

    public GameObject storageScale;
    public GameObject state2Prefab;
    public GameObject state3Prefab;
    public GameObject state4Prefab;
    public GameObject state5Prefab;

    public GameObject pivot;

    private SkinnedMeshRenderer[] rend;
    private Color32 deathColor = new Color32(255, 255, 255, 255);


    
    

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Bacteria")
        {
            isState1 = true;

            rend = other.gameObject.GetComponentsInChildren<SkinnedMeshRenderer>();

            foreach(SkinnedMeshRenderer r in rend)
            {
                r.material.color = deathColor;
                r.material.SetColor("_EmissionColor", Color.black);
            }

            other.gameObject.tag = "Bacteria State 1";

            
        }


        if(other.gameObject.tag == "Bacteria State 1")
        {
            isState2 = true;

            Vector3 posState2 = other.gameObject.transform.position;

            GameObject s2 = Instantiate(state2Prefab, posState2, other.gameObject.transform.rotation);
            other.gameObject.SetActive(false);

            s2.transform.parent = pivot.transform;
            //s2.transform.localScale = storageScale.transform.localScale;

            
        }


        if(other.gameObject.tag == "Bacteria State 2")
        {
            isState3 = true;

            Vector3 posState3 = other.gameObject.transform.position;

            GameObject s3 = Instantiate(state3Prefab, posState3, other.gameObject.transform.rotation);
            other.gameObject.SetActive(false);

            s3.transform.parent = pivot.transform;
            //s3.transform.localScale = storageScale.transform.localScale;

            
        }


        if (other.gameObject.tag == "Bacteria State 3")
        {
            isState4 = true;

            Vector3 posState4 = other.gameObject.transform.position;

            GameObject s4 = Instantiate(state3Prefab, posState4, other.gameObject.transform.rotation);
            other.gameObject.SetActive(false);

            s4.transform.parent = pivot.transform;
            //s4.transform.localScale = storageScale.transform.localScale;
        }


        if (other.gameObject.tag == "Bacteria State 4")
        {
            isState5 = true;

            Vector3 posState5 = other.gameObject.transform.position;

            GameObject s5 = Instantiate(state3Prefab, posState5, other.gameObject.transform.rotation);
            other.gameObject.SetActive(false);

            s5.transform.parent = pivot.transform;
            //s5.transform.localScale = storageScale.transform.localScale;
        }


        if (other.gameObject.tag == "Bacteria State 5")
        {
            //isState5 = true;

            Destroy(other.gameObject);

            
        }
    }
}
