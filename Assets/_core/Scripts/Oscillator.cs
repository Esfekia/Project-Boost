using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oscillator : MonoBehaviour
{
    Vector3 startingPosition;
    [SerializeField]
    Vector3 movementVector;
    [SerializeField]
    float period = 2f;
    [SerializeField]
    [Range(0, 1)]
    float movementFactor = 0f;
    void Start()
    {
        startingPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (period <= Mathf.Epsilon) { return; }
        float cycles = Time.time / period; // grows continually from 0
        const float tau = Mathf.PI * 2f; // about 6.28
        float rawSineWave = Mathf.Sin(cycles * tau); // goes from -1 to +1
        movementFactor = rawSineWave / 2f + 0.5f; // recalculated & goes from 0 to 1

        Vector3 offset = movementVector * movementFactor;
        transform.position = startingPosition + offset;
    }
}
