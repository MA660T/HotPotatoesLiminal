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

    public void Bounce(Vector2 direction)
    {
        GetComponent<Rigidbody>().AddForce(direction);
    }
}
