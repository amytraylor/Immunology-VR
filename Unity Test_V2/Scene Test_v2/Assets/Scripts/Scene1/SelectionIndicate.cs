using UnityEngine;
using System.Collections;

public class SelectionIndicate : MonoBehaviour
{

    RaycastManager rm;

    // Use this for initialization
    void Start()
    {
        rm = GameObject.FindObjectOfType<RaycastManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (rm.selectedObject != null)
        {


            Bounds bigBounds = rm.selectedObject.GetComponentInChildren<Renderer>().bounds;

            // This "diameter" only works correctly for relatively circular or square objects
            float diameter = bigBounds.size.z;
            diameter *= 1.25f;

            this.transform.position = new Vector3(bigBounds.center.x, 0, bigBounds.center.z);
            this.transform.localScale = new Vector3(bigBounds.size.x, bigBounds.size.y, bigBounds.size.z);
        }
    }
}
