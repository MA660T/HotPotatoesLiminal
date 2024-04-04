using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Spawner : MonoBehaviour
{
    Vector3 position;
    public ShapeBase[] shapes;

    [Header("Check box for random spawning")]
    public bool testMode;
    
    //TODO: Tie to GameController to handle objects to spawn

    public void SpawnGivenObject(ShapeBase shapeToSpawn)
    {
        if (spawnedObjs < maxObjects)
        {
            Instantiate(shapes[(int)shapeToSpawn.myShape],
                new Vector3(position.x + Random.Range(0.5f, 3f), position.y, position.z + Random.Range(0.5f, 3f)), 
                Quaternion.identity);
            spawnedObjs++;
        }
    }
    
    public void SpawnGivenObject(int shapesEnumValue)
    {
        if (spawnedObjs < maxObjects)
        {
            Instantiate(shapes[shapesEnumValue],
                new Vector3(position.x + Random.Range(0.5f, 3f), position.y, position.z + Random.Range(0.5f, 3f)), 
                Quaternion.identity);
            spawnedObjs++;
        }
    }

    //HACK: Spawn random (up to 3)
    #region HACK SPAWN

    [HideInInspector]
    public int spawnedObjs = 0;
    public int maxObjects = 3;
    
    int hackSpawns = 0;
    
    private void Start()
    {
        if(testMode)
            StartCoroutine(HackSpawnObject(2f));
        
        position = transform.position;
    }

    IEnumerator HackSpawnObject(float delay)
    {
        while (hackSpawns < maxObjects)
        {
            Instantiate(shapes[Random.Range(0, 2)], new Vector3(position.x + Random.Range(0.5f, 3f), position.y, position.z + Random.Range(0.5f, 3f)), Quaternion.identity);
            hackSpawns++;
            
            yield return new WaitForSeconds(delay);
        }
    }
    #endregion
}
