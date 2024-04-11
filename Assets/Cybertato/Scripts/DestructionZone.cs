using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructionZone : MonoBehaviour
{
    [Header("SETUP VARIABLES")]
    [Tooltip("The spawner in the level")]
    public Spawner spawner;
    AudioSource aud;

    private void Start()
    {
        aud = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision other)
    {
        var shape = other.gameObject.GetComponent<ShapeBase>();

        if (shape != null)
        {
            spawner.SpawnGivenObject(shape);
            aud.Play();
            Destroy(other.gameObject);
            spawner.spawnedObjs --;
        }
    }
}
