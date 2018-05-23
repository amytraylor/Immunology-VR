using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectHighlighter : MonoBehaviour {


    public bool isHighlighted = false;

    public Material [] material;

    private Renderer rend;

    private void Awake()
    {
        
    }

    // Use this for initialization
    void Start () {
        rend = GetComponent<Renderer>();
        rend.enabled = true;
        rend.sharedMaterial = material[0];
    }
	
	// Update is called once per frame
	void Update () {

        if(isHighlighted){
            rend.sharedMaterial = material[1];
        }
        else{
            rend.sharedMaterial = material[0];
        }

	}

    
    private void LateUpdate()
    {
        //isHighlighted = false;
    }
}
