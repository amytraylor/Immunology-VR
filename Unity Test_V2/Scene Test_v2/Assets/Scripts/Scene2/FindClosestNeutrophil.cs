using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindClosestNeutrophil : MonoBehaviour {

    public GameObject[] neutrophils;
    GameObject teleportTarget;




	// Use this for initialization
	void Start () {
        teleportTarget = FindClosest();

        

    }
	

    public GameObject FindClosest()
    {
        neutrophils = GameObject.FindGameObjectsWithTag("Neutrophil");
        GameObject closest = null;
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;

        foreach (GameObject n in neutrophils)
        {
            Vector3 diff = n.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if(curDistance < distance)
            {
                closest = n;
                distance = curDistance;
            }
        }

        return closest;
    }





	// Update is called once per frame
	void Update () {
        Debug.DrawLine(transform.position, teleportTarget.transform.position, Color.red);
    }
}
