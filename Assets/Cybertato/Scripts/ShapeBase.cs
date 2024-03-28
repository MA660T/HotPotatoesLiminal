using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Shape
{
    Sphere,
    Cube,
    Bouncer
}

public class ShapeBase : MonoBehaviour
{
    public Shape myShape;

    private void OnEnable()
    {
        //Player.BounceEvent += Bounce;
    }

    void Bounce(ShapeBase obj, Vector2 direction)
    {
        //TODO: Use Rigidbody.AddForce
    }
}
