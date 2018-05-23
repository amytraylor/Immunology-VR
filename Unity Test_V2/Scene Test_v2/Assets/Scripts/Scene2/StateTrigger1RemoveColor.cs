using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateTrigger1RemoveColor : MonoBehaviour
{

    private SkinnedMeshRenderer[] rend;
    private Color32 deathColor = new Color32(255, 255, 255, 255);
    public GameObject explosionPrefab;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Captured Bacteria")
        {
            Vector3 pos = other.gameObject.transform.position;
            GameObject litTransition = Instantiate(explosionPrefab, pos, transform.rotation);

            rend = other.gameObject.GetComponentsInChildren<SkinnedMeshRenderer>();

            foreach (SkinnedMeshRenderer r in rend)
            {
                r.material.color = deathColor;
                r.material.SetColor("_EmissionColor", Color.black);
            }

            other.gameObject.tag = "Bacteria State 1";
            other.gameObject.transform.localScale = other.gameObject.transform.localScale * 0.9f;

            Destroy(litTransition, 2f);
        }
    }

}
