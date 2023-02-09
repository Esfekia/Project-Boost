using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShaderControl : MonoBehaviour
{
    public float adjustedTime = 0.0f;
    void Update()
    {
        adjustedTime = Time.time * 20;
        Shader.SetGlobalFloat("_ShaderDissolve", (1 - 1/adjustedTime));


    }
}
