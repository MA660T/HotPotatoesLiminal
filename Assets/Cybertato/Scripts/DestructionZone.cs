using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructionZone : MonoBehaviour
{
    public Spawner spawner;

    private void OnCollisionEnter(Collision other)
    {
        var shape = other.gameObject.GetComponent<ShapeBase>();

        if (shape != null)
        {
            spawner.SpawnGivenObject(shape);

            Destroy(other.gameObject);
            spawner.spawnedObjs -= 1;
        }
    }
}
