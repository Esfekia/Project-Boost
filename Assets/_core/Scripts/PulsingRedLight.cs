using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PulsingRedLight : MonoBehaviour
{
    public float maxIntensity = 20f;
    public float speed = 1f;
    public float minIntensity = 1f;

    void Update()
    {
        PulseLight();
    }

    void PulseLight()
    {
        {
            float intensity = Mathf.PingPong(Time.time * speed, maxIntensity);
            intensity += minIntensity;
            GetComponent<Light>().intensity = intensity;
        }
    }
}
