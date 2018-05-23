using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthSausageBacteria : MonoBehaviour {

    float lerpDuration = 5f;
    float currentLerpTime = 0f;

    public GameObject scoreTextPrefab;


    public Renderer[] rend;
    

    private Color32 deathColor = new Color32(255, 255, 255, 255);
    private Color32 liveColor;


    //private float t;
    private int healthStart = 200;
    private bool isDead;
    private bool isHit;
    private bool isNetsHit;
    public int healthCurrent;
    private int damage;
    // Use this for initialization
    void Start()
    {
        healthCurrent = healthStart;
        rend = GetComponentsInChildren<Renderer>();

    }

    private void Update()
    {
        if (isHit || isNetsHit)
        {
            currentLerpTime += Time.deltaTime;
            if (currentLerpTime > lerpDuration)
            {
                currentLerpTime = lerpDuration;
            }

            float percent = currentLerpTime / lerpDuration;


            foreach (Renderer r in rend)
            {
                liveColor = r.material.color;

                r.material.color = Color32.Lerp(liveColor, deathColor, percent);

                if (healthCurrent < 100)
                {
                    r.material.SetColor("_EmissionColor", Color.black);
                    Destroy(GetComponent<Rotate>());
                    Destroy(GetComponent<Animation>());

                }

            }
        }

    }


    public void GotHit()
    {
        isHit = true;

        healthCurrent -= 1;
        //damage = healthStart - healthCurrent;


        if (healthCurrent <= 0)
        {

            GameObject scoreText = Instantiate(scoreTextPrefab, transform.position, transform.rotation);
            Destroy(scoreText, 1f);

            ScoreManager.score += 100;
            Destroy(gameObject);

        }

    }

    public void NetsHit()
    {
        isNetsHit = true;

        healthCurrent -= 110;
        //damage = healthStart - healthCurrent;

        GameObject scoreText = Instantiate(scoreTextPrefab, transform.position, transform.rotation);
        Destroy(scoreText, 1f);

        ScoreManager.score += 100;


    }


    void Death()
    {

        if (healthCurrent <= 0)
        {
            isDead = true;
        }

    }
}
