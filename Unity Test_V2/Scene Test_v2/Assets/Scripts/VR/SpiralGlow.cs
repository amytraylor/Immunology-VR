using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiralGlow : MonoBehaviour
{

    void Update()
    {
        Renderer rend = GetComponent<Renderer>();
        Material mat = rend.material;

        float emission = Mathf.PingPong(Time.time, 1.0f);
        Color baseColor = new Color32(86, 177, 255, 255); //Replace this with whatever you want for your base color at emission level '1'

        Color finalColor = baseColor * Mathf.LinearToGammaSpace(emission);

        mat.SetColor("_EmissionColor", finalColor);
    }
}
