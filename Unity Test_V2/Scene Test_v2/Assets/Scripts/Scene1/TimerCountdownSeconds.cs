﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerCountdownSeconds : MonoBehaviour {

	public Text timerText;
	public float myCoolTimer=40;
	private bool timerIsActive = true;

	// Use this for initialization
	void Start () {
		timerText = GetComponent<Text> ();
	}

	// Update is called once per frame
	void Update () {
		if (timerIsActive) {

			myCoolTimer -= Time.deltaTime;
			timerText.text = myCoolTimer.ToString ("f0");
			//print (myCoolTimer);
			if (myCoolTimer <= 0) {
				myCoolTimer = 0;
				timerIsActive = false;
			}
		}

	}
}

