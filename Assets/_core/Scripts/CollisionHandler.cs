using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
                break;
            case "Fuel":
                print("Fuel up!");
                break;
            default:
                print("Dead");
                break;
        }
    }
}
