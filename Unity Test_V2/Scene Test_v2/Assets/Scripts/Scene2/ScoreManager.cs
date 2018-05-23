using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {


    public static int score;
    public int scoreRead;

    private int tempHealth;
    private Text text;



	// Use this for initialization
	void Start () {

        text = GetComponent<Text>();
        scoreRead = score;
        score = 0;
	}
	
	// Update is called once per frame
	void Update () {

        tempHealth = (int)PlayerHealth.CurrentHealth;
        text.text = "Host Health: " + (tempHealth + score);
        scoreRead = score;
	}
}
