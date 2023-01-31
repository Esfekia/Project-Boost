using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public Rigidbody rigidBody;
    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessThrust();
        ProcessTurns();
    }

    private void ProcessThrust()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            rigidBody.AddRelativeForce(Vector3.up);
        }

    }

    private void ProcessTurns()
    {
        if (Input.GetKey(KeyCode.A))
        {
            print("A key was pressed");
        }
        else if (Input.GetKey(KeyCode.D))
        {
            print("D key was pressed");
        }
    }
}
