using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetManager : MonoBehaviour {

    public Material mButtonUnlit;
    public GameObject netsButton;
    public GameObject screen;

    private Renderer rendNets;

    private NETSv1 netsScript;
    private Teleportation teleportScript;
    private WeaponShift wShiftScript;



    private void Awake()
    {
        netsScript = GetComponent<NETSv1>();
        teleportScript = GetComponent<Teleportation>();
        wShiftScript = GetComponent<WeaponShift>();

        rendNets = netsButton.GetComponent<Renderer>();
    }


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (teleportScript.isTeleported)
        {
            netsScript.ResetNETS();

            wShiftScript.isNETS = false;
            rendNets.material = mButtonUnlit;

            teleportScript.isTeleported = false;
            teleportScript.enabled = false;

            screen.SetActive(false);
        }


	}



}
