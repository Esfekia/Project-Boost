using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public AudioSource thrustSound;
    public Rigidbody rigidBody;
    public float mainThrust = 500.0f;
    public float rotationValue = 50.0f;
    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessThrust();
        ProcessRotation();
    }

    private void ProcessThrust()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            rigidBody.AddRelativeForce(Vector3.up * mainThrust * Time.deltaTime);
            if (!thrustSound.isPlaying)
            {
                thrustSound.Play();                
            }
        }
        else
        {
            thrustSound.Stop();
        }
    }

    private void ProcessRotation()
    {
        if (Input.GetKey(KeyCode.A))
        {
            // Rotate Gameobject around its Z axis positively
            ApplyRotation(rotationValue);

        }
        else if (Input.GetKey(KeyCode.D))
        {
            // Rotate Gameobject around its Z axis negatively
            ApplyRotation(-rotationValue);
        }
    }

    private void ApplyRotation(float rotationThisFrame)
    {
        rigidBody.freezeRotation = true; // Freezing rotation so we can manually rotate
        transform.Rotate(Vector3.forward * rotationThisFrame * Time.deltaTime);
        rigidBody.freezeRotation = false; // Unfreezing rotation so the physics system can take over
    }
}
