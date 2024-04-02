using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructionZone : MonoBehaviour
{
    public Spawner spawner;

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.GetComponent<ShapeBase>() != null)
        {
            Destroy(other.gameObject);
            spawner.spawnedObjs -= 1;
        }
    }
}
