using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    AudioSource audioSource;
    public AudioClip crashSound;
    public AudioClip landedSound;

    public ParticleSystem explosionParticles;
    public ParticleSystem hexagonParticles;
    public ParticleSystem healParticles;

    public float delayInSeconds = 1.0f;
    bool inTransition = false;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter(Collider other)
    {
        StartNextLevelSequence();
    }

    void OnCollisionEnter(Collision collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Friendly":                
                break;
            case "Finish":                
                //Load next scene
                StartNextLevelSequence();
                break;
            case "Fuel":                
                break;
            default:
                StartCrashSequence();
                break;
        }
    }
    void StartCrashSequence()
    {
        if (!inTransition)
        {
            explosionParticles.Play();
            audioSource.Stop();
            audioSource.PlayOneShot(crashSound, 1);            
            inTransition = true;
        }
        
        
        // add particle effect upon crash
        GetComponent<Movement>().enabled = false;
        Invoke("ReloadScene",delayInSeconds);
    }
    
    void StartNextLevelSequence()
    {
        if (!inTransition)
        {
            StopGameObjectMovement();
            hexagonParticles.Play();
            healParticles.Play();
            audioSource.Stop();
            audioSource.PlayOneShot(landedSound, 1);            
            inTransition = true;
        }
        GetComponent<Movement>().enabled = false;
        Invoke("LoadNextScene", delayInSeconds);
    }
    private void ReloadScene()
    {
        // Reload current scene
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }

    private void LoadNextScene()
    {
        // Load next scene
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;
        if (nextSceneIndex == SceneManager.sceneCountInBuildSettings)
        {
            nextSceneIndex = 0; // Loop back to start
        }
        SceneManager.LoadScene(nextSceneIndex);
    }
    
    private void StopGameObjectMovement()
    {
        {
            // Stop Gameobject movement
            GetComponent<Rigidbody>().velocity = Vector3.zero;
            GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
            GetComponent<Rigidbody>().useGravity = false;
        }
    }
    
}
