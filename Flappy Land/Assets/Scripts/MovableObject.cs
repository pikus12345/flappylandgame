using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovableObject : LevelObject
{
    public float RotatingSpeed;
    public MovableObjectType Type;
    private void FixedUpdate()
    {
        transform.Rotate(0,0,Time.deltaTime*RotatingSpeed);
    }
}
