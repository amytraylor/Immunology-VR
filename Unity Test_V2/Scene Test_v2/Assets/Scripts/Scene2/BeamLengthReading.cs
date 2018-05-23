using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BeamLengthReading : MonoBehaviour {


    private Text reading;
    public GameObject controllerR;
    private MagicMoveV4 _mmScript;

    private void Awake()
    {
        reading = GetComponent<Text>();
        _mmScript = controllerR.GetComponent<MagicMoveV4>();
    }

	
	// Update is called once per frame
	void Update () {

        reading.text = _mmScript.beamLength.ToString("0");

	}
}
