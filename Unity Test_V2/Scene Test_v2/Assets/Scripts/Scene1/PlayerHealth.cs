using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {

	static public float CurrentHealth = 900f;
	static public float MaxHealth = 900f; 
	public float delay; 
	public Image fill;
	static public float healthMid = 400f;
	static public float healthLow = 200f;

	public Slider healthbar;

	private float startTime;
	private float delayedTime;
	private Color32 col;
    private Color32 colReset = new Color32(0, 255, 65, 255);
    public float healthCombined;

    public bool isStart;
    public bool isDead;

    // Use this for initialization
    void Start () {
		startTime = Time.time;
		delayedTime = Time.time + delay;

        //CurrentHealth = MaxHealth;
        healthCombined = CurrentHealth + ScoreManager.score;

        healthbar.value = CalculateHealth ();
	}
		

	// Update is called once per frame
	void Update () {
		//float pastTime = Time.time - startTime;

		if (Time.time>delayedTime && isStart) {
			DealDamage (1);
			delayedTime = Time.time + delay;
		}
			
	}


	void DealDamage (float damageValue){

		CurrentHealth -= damageValue;
		healthbar.value = CalculateHealth ();

		if ((CurrentHealth + ScoreManager.score) <= healthMid && (CurrentHealth + ScoreManager.score) > healthLow) {
			col = new Color32(255, 164, 0, 255);
			fill.color = col;
		}

        if((CurrentHealth + ScoreManager.score) > healthMid)
        {
            fill.color = colReset;
        }

		if ((CurrentHealth + ScoreManager.score) < healthLow) {
			col = new Color32(255, 26, 0, 255);
			fill.color = col;
		}

		

		if ((CurrentHealth + ScoreManager.score) <= 0) {
			Die ();
		}

	}


	float CalculateHealth (){
		return (CurrentHealth + ScoreManager.score) / MaxHealth;
	
	}


	void Die(){
        healthCombined = 0;
		Debug.Log ("You're Dead");
        isDead = true;
	}
}
