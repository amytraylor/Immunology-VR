using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SelfDestructionCountdown : MonoBehaviour {

    public int Minutes = 0;
    public int Seconds = 0;
    public GameObject controller;
    
    public Light _lightExposion;

    //public Text m_text;
    public float m_leftTime;
    private TextMeshPro meshText;
    public GameObject textMesh;

    public AudioClip teleportWarning;
    public GameObject rightController;
    AudioSource warningAudio;
    bool isOneMinLeft;
    

    private NETSv1 netsScript;

    private void Awake()
    {
        //m_text = GetComponent<Text>();
        m_leftTime = GetInitialTime();

        netsScript = controller.GetComponent<NETSv1>();
        meshText = textMesh.GetComponent<TextMeshPro>();
        warningAudio = rightController.GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (m_leftTime > 0f && netsScript.isTriggerDown)
        {
            //  Update countdown clock
            m_leftTime -= Time.deltaTime;
            Minutes = GetLeftMinutes();
            Seconds = GetLeftSeconds();

            if(Minutes < 1 && !isOneMinLeft)
            {
                isOneMinLeft = true;
                warningAudio.PlayOneShot(teleportWarning, 1f);
            }


            //  Show current clock
            if (m_leftTime > 0f)
            {
                meshText.text = Minutes + ":" + Seconds.ToString("00");
            }
            else
            {
                //  The countdown clock has finished
                meshText.text = "0:00";
                _lightExposion.intensity = 7f;
            }
        }
    }

    private float GetInitialTime()
    {
        return Minutes * 60f + Seconds;
    }

    private int GetLeftMinutes()
    {
        return Mathf.FloorToInt(m_leftTime / 60f);
    }

    private int GetLeftSeconds()
    {
        return Mathf.FloorToInt(m_leftTime % 60f);
    }
}
