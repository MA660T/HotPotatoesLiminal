using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;

public enum Shape
{
    Sphere,
    Cube,
    Pyramid
}

public class ShapeBase : MonoBehaviour
{
    [Header("SETUP VARIABLES")]
    [Tooltip("Shape naturally must match model")]
    public Shape myShape;
    
    // Want to keep the randomness within a 0-1 range, tweak as necessary
    [Header("FREELY ADJUSTABLE VARIABLES")]
    [Tooltip("Adjust as needed for fun bounce")]
    public float forceMultiplier = 1;
    
    public void Bounce(Vector3 direction)
    {
        GetComponent<Rigidbody>().AddForce(direction * forceMultiplier, ForceMode.Impulse);
    }
}
