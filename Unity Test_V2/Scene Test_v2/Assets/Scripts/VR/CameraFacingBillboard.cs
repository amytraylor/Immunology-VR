using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFacingBillboard : MonoBehaviour {

    //public Camera m_Camera;
    private GameObject cameraMain;
   

    void Update()
    {
        cameraMain = GameObject.FindGameObjectWithTag("MainCamera");
        
        //transform.LookAt(transform.position + m_Camera.transform.rotation * Vector3.back, m_Camera.transform.rotation * Vector3.up);
        //transform.LookAt(m_Camera.transform.position);
        transform.LookAt(cameraMain.transform.position);
    }
}
