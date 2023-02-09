using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PulseEmmission : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PulseObjectEmmission();
    }

    void PulseObjectEmmission()
    {
        float emission = Mathf.PingPong(Time.time, 1.0f);
        Color baseColor = Color.red; //Replace this with whatever you want for your base color at emission level '1'
        Color finalColor = baseColor * Mathf.LinearToGammaSpace(emission);
        GetComponent<Renderer>().material.SetColor("_EmissionColor", finalColor);
    }
}
