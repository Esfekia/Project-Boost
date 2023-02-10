using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    public bool collisionDisable = false;

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

    private void Update()
    {
        DebugLoadNextLevel();
        DebugDisableCollisions();        
    }

    private void OnParticleCollision(GameObject other)
    {
        Debug.Log("Collided With Laser!");
        StartCrashSequence();
    }
    private void OnTriggerEnter(Collider other)
    {
        // Check if tag is finish
        if (other.gameObject.tag == "Finish")
        {
            StartNextLevelSequence();
        }   
        
    }

    void OnCollisionEnter(Collision collision)
    {
        if (!collisionDisable)
        {
            switch (collision.gameObject.tag)
            {
                case "Friendly":                    
                    break;
                case "Triggerer":
                    break;
                case "Finish":
                    Debug.Log("Finish");
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
    
    public void StartNextLevelSequence()
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

    private void DebugDisableCollisions()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            Debug.Log("Switching collision for debug mode..");
            collisionDisable = !collisionDisable;
        }
    }
    private void DebugLoadNextLevel()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            Debug.Log("Loading next level for debug mode..");
            StartNextLevelSequence();
        }
    }

}
