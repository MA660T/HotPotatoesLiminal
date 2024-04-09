using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;

public enum Shape
{
    Sphere,
    Cube,
    Bouncer
}

public class ShapeBase : MonoBehaviour
{
    public Shape myShape;
    
    // Want to keep the randomness within a 0-1 range, tweak as necessary
    public float forceMultiplier;

    public void Bounce(Vector3 direction)
    {
        GetComponent<Rigidbody>().AddForce(direction * forceMultiplier);
    }
}
