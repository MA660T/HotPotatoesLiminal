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
    [Tooltip("Fill in all shapes to spawn")]
    public ShapeBase[] shapes;

    //TODO: TWEAK RANDOMNESS OF SPAWN RANGE TO BE HITTABLE
    //TODO: Tie to GameController to handle objects to spawn

    private void Start()
    {
        if(testMode)
            StartCoroutine(HackSpawnObject(2f));
        
        position = transform.position;
    }
    
    public void SpawnGivenObject(ShapeBase shapeToSpawn)
    {
        if (spawnedObjs < maxObjs)
        {
            Instantiate(shapes[(int)shapeToSpawn.myShape],
                new Vector3(position.x + Random.Range(0.1f, 0.5f), position.y, position.z + Random.Range(0.5f, 3f)), 
                Quaternion.identity);
            spawnedObjs++;
        }
    }
    
    public void SpawnGivenObject(int shapesEnumValue)
    {
        if (spawnedObjs < maxObjs)
        {
            Instantiate(shapes[shapesEnumValue],
                new Vector3(position.x + Random.Range(0.1f, 0.5f), position.y, position.z + Random.Range(0.5f, 3f)), 
                Quaternion.identity);
            spawnedObjs++;
        }
    }

    //HACK: Spawn random
    #region HACK SPAWN
    
    [Header("AUTOMATIC SPAWNING FOR TESTING ONLY")]
    [Tooltip("Check box for random spawns")]
    public bool testMode;
    [Tooltip("Max number of objects, ONLY FOR TEST MODE")]
    public int maxObjects = 3;
    
    private int hackSpawns = 0;

    IEnumerator HackSpawnObject(float delay)
    {
        while (hackSpawns < maxObjects)
        {
            Instantiate(shapes[Random.Range(0, 2)], new Vector3(position.x + Random.Range(0.1f, 0.5f), position.y, position.z + Random.Range(0.1f, 0.5f)), Quaternion.identity);
            hackSpawns++;
            
            yield return new WaitForSeconds(delay);
        }
    }
    #endregion
}
