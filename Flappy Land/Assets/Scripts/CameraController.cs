using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float Movespeed;

    
    private void LateUpdate()
    {
        transform.Translate(Vector2.right * Movespeed * Time.deltaTime);
    }
}
