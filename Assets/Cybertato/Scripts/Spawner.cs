using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Spawner : MonoBehaviour
{
    [HideInInspector]
    public int spawnedObjs = 0;
    [HideInInspector]
    public int maxObjs = Int32.MaxValue;
    
    private Vector3 position;
    [Header("SETUP VARIABLES")]
    [Tooltip("Fill in all shapes to spawn, MUST MATCH SHAPE ENUM")]
    public ShapeBase[] shapes;

    [Header("ADJUSTABLE VARIABLES")]
    [Tooltip("Maximum X value to spawn")]
    public float upperSpawnXLimit = 0.5f;
    [Tooltip("Minimum X value to spawn")]
    public float lowerSpawnXLimit = 0.1f;

    [Tooltip("Maximum Z value to spawn")]
    public float upperSpawnZLimit = 3f;
    [Tooltip("Minimum Z value to spawn")]
    public float lowerSpawnZLimit = 0.5f;

    private void Start()
    {
        position = transform.position;
    }
    
    public void SpawnGivenObject(ShapeBase shapeToSpawn)
    {
        if (spawnedObjs < maxObjs)
        {
            Instantiate(shapes[(int)shapeToSpawn.myShape],
                new Vector3(position.x + Random.Range(lowerSpawnXLimit, upperSpawnXLimit), position.y, position.z + Random.Range(lowerSpawnZLimit, upperSpawnZLimit)), 
                Quaternion.identity);
            spawnedObjs++;
        }
    }
    
    public void SpawnGivenObject(int shapesEnumValue)
    {
        if (spawnedObjs < maxObjs)
        {
            Instantiate(shapes[shapesEnumValue],
                new Vector3(position.x + Random.Range(lowerSpawnXLimit, upperSpawnXLimit), position.y, position.z + Random.Range(lowerSpawnZLimit, upperSpawnZLimit)), 
                Quaternion.identity);
            spawnedObjs++;
        }
    }
}
