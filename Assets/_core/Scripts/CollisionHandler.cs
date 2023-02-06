using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    public float delayInSeconds = 1.0f;
    void OnCollisionEnter(Collision collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Friendly":
                print("OK");
                break;
            case "Finish":
                print("Finished");
                //Load next scene
                StartNextLevelSequence();
                break;
            case "Fuel":
                print("Fuel up!");
                break;
            default:
                StartCrashSequence();
                break;
        }
    }
    void StartCrashSequence()
    {
        // add sfx upon crash
        // add particle effect upon crash
        GetComponent<Movement>().enabled = false;
        Invoke("ReloadScene",delayInSeconds);
    }
    
    void StartNextLevelSequence()
    {
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
}
