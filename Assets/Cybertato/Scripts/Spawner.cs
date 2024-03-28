using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Spawner : MonoBehaviour
{
    //TODO: Tie to GameController to handle objects to spawn

    //HACK: Spawn random (up to 3)

    #region HACK SPAWN
    public ShapeBase[] shapes;
    private int spawnedObjs = 0;

    private void Start()
    {
        StartCoroutine(SpawnObject(2f));
    }

    IEnumerator SpawnObject(float delay)
    {
        while (spawnedObjs < 3)
        {
            Instantiate(shapes[Random.Range(0, 2)], new Vector3(transform.position.x + Random.Range(0.5f, 3f), transform.position.y, transform.position.z + Random.Range(0.5f, 3f)), Quaternion.identity);
            spawnedObjs++;
            
            yield return new WaitForSeconds(delay);
        }
    }
    #endregion
}
