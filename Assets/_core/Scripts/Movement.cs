using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip thrustSound;
    public Rigidbody rigidBody;

    public ParticleSystem afterBurner;
    public ParticleSystem leftBooster;
    public ParticleSystem rightBooster;

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
            if (!audioSource.isPlaying)
            {
                afterBurner.Play();
                audioSource.PlayOneShot(thrustSound, 1);                
            }
        }
        else
        {
            audioSource.Stop();
            afterBurner.Stop();
        }
    }

    private void ProcessRotation()
    {
        if (Input.GetKey(KeyCode.A))
        {
            // Rotate Gameobject around its Z axis positively
            ApplyRotation(rotationValue);
            if (!rightBooster.isPlaying)
            {
                rightBooster.Play();
            }

        }
        else if (Input.GetKey(KeyCode.D))
        {
            // Rotate Gameobject around its Z axis negatively
            ApplyRotation(-rotationValue);
            if (!leftBooster.isPlaying)
            {
                leftBooster.Play();
            }
        }
        else
        {
            leftBooster.Stop();
            rightBooster.Stop();
        }
    }

    private void ApplyRotation(float rotationThisFrame)
    {
        rigidBody.freezeRotation = true; // Freezing rotation so we can manually rotate
        transform.Rotate(Vector3.forward * rotationThisFrame * Time.deltaTime);
        rigidBody.freezeRotation = false; // Unfreezing rotation so the physics system can take over
    }
}
