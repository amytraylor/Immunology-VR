using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalEnter : MonoBehaviour
{

    public GameObject stepIntoPortalInfo;


    private void Awake()
    {
        stepIntoPortalInfo.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        stepIntoPortalInfo.SetActive(true);

    }

    private void OnTriggerStay(Collider other)
    {
        stepIntoPortalInfo.SetActive(true);

    }

    private void OnTriggerExit(Collider other)
    {
        stepIntoPortalInfo.SetActive(false);

    }
}
