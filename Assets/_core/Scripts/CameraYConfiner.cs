using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraYConfiner : MonoBehaviour
{
    public GameObject player;
    void Update()
    {
        FixCameraXtoGameObject();
    }

    void FixCameraXtoGameObject()
    {
        Vector3 cameraPosition = Camera.main.transform.position;
        Vector3 gameObjectPosition = player.transform.position;
        cameraPosition.x = gameObjectPosition.x;
        Camera.main.transform.position = cameraPosition;
    }
}
