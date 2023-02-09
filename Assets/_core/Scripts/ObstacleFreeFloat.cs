using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleFreeFloat : MonoBehaviour
{

    public float floatSpeed = 0.25f;
    // Start is called before the first frame update
    void Start()
    {
        Vector3 obstaclePosition = transform.position;
        Vector3 obstatcleRotation = transform.rotation.eulerAngles;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        MakeObjectFloatRandomly();
    }

    void MakeObjectFloatRandomly()
    {
        Vector3 obstaclePosition = transform.position;
        Vector3 obstacleRotation = transform.rotation.eulerAngles;
        obstaclePosition.y += Mathf.Sin(Time.time) * 0.1f * floatSpeed;
        obstacleRotation.y += Mathf.Sin(Time.time) * 0.1f * floatSpeed;
        transform.position = obstaclePosition;
        transform.rotation = Quaternion.Euler(obstacleRotation);
    }

  
        
}
