using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndothelialGlow : MonoBehaviour
{

    void Update()
    {
        Renderer rend = GetComponent<Renderer>();
        Material mat = rend.material;

        float emission = Mathf.PingPong(Time.time*3, 0.5f);
        Color baseColor = new Color32(182, 159, 139, 225); //Replace this with whatever you want for your base color at emission level '1'

        Color finalColor = baseColor * Mathf.LinearToGammaSpace(emission);

        mat.SetColor("_EmissionColor", finalColor);
    }
}
