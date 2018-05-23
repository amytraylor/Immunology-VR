using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using cakeslice;

public class SelectionHighlight_teleportation : MonoBehaviour
{


    private Transform temp;

    private SteamVR_TrackedObject trackedObj;
    private SteamVR_Controller.Device Controller
    {
        get { return SteamVR_Controller.Input((int)trackedObj.index); }
    }

    private Outline _outline;


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
            RaycastHit hit;
            int layer_mask = 1 << 10;

            if (Physics.Raycast(trackedObj.transform.position, transform.forward, out hit, 800, layer_mask))
            {

                if (hit.collider.tag == "Highlightable")
                {
                    temp = hit.transform;
                    _outline = hit.collider.gameObject.GetComponent<Outline>();
                    _outline.isHit = true;

                    Debug.Log("Highlightable is hit!");
                }

            }
            else
            {

                _outline.isHit = false;

            }

        }
        else
        {
            if (_outline.isHit == true)
            {
                _outline.isHit = false;
            }

        }


    }
}
