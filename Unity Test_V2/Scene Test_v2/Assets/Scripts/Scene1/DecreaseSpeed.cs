using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SWS;

public class DecreaseSpeed : MonoBehaviour
{

    public GameObject player;

    public float speedChange;

    private splineMove splineMoveScript;

    private void Awake()
    {
        splineMoveScript = player.GetComponent<splineMove>();
    }

    
    void OnTriggerEnter(Collider other)
    {
        splineMoveScript.ChangeSpeed(speedChange); 

            Debug.Log("Current speed is: " + speedChange);
        
    }

    
}
