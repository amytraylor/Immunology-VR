using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetection : MonoBehaviour {

    public bool isColliding;

    
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Bacteria" || collision.gameObject.tag == "Environment" || collision.gameObject.tag == "Bacteria Sausage" || collision.gameObject.tag == "Bacteria Sausage Ends" || collision.gameObject.tag == "Bacteria Bighead")
        {
            isColliding = true;
            //Debug.Log("collided!");

        }
        
    }

}
