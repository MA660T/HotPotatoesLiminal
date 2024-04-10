using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Container : MonoBehaviour
{
    private void OnTriggerExit(Collider other)
    {
        ShapeBase shape = other.GetComponent<ShapeBase>();

        if (shape != null)
        {
            shape.gameObject.GetComponent<Rigidbody>().velocity *= -0.5f;
        }
    }
}
