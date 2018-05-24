using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastManager : MonoBehaviour
{

    public GameObject selectedObject;

    private SteamVR_TrackedObject trackedObj;

        


    //private Vector3 hitPoint;

    private SteamVR_Controller.Device Controller
    {
        get { return SteamVR_Controller.Input((int)trackedObj.index); }
    }


    void Awake()
    {
        trackedObj = GetComponent<SteamVR_TrackedObject>();
    }




    // Use this for initialization
    void Start()
    {

        
    }

    // Update is called once per frame
    void Update()
    {


        if (Controller.GetPress(SteamVR_Controller.ButtonMask.Touchpad))
        {

           // Ray ray = new Ray(trackedObj.transform.position, transform.forward);

            RaycastHit hit;

            
            if (Physics.Raycast(trackedObj.transform.position, transform.forward, out hit, 500))
            {
                //hitPoint = hit.point;

                GameObject hitObject = hit.transform.root.gameObject;

                SelectObject(hitObject);

            }
            else
            {
                ClearSelection();
            }

        }
        

    }

    void SelectObject(GameObject obj)
    {
        if (selectedObject != null)
        {
            if (obj == selectedObject)
                return;

            ClearSelection();
        }

        selectedObject = obj;

        Renderer[] rs = selectedObject.GetComponentsInChildren<Renderer>();
        foreach (Renderer r in rs)
        {
            Material m = r.material;
            m.color = Color.green;
            r.material = m;
        }
    }

    void ClearSelection()
    {
        if (selectedObject == null)
            return;

        Renderer[] rs = selectedObject.GetComponentsInChildren<Renderer>();
        foreach (Renderer r in rs)
        {
            Material m = r.material;
            m.color = Color.white;
            r.material = m;
        }


        selectedObject = null;
    }

}
