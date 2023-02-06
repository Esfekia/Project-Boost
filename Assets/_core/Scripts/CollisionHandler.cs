using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
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
                LoadNextScene();
                break;
            case "Fuel":
                print("Fuel up!");
                break;
            default:
                print("Dead");
                //Reload current scene
                ReloadScene();
                break;
        }
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
