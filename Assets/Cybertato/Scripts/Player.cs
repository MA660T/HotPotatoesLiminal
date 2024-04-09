using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Player : MonoBehaviour, IPlayer
{
    public GameObject[] PlayerHands;

    private void OnCollisionEnter(Collision collision)
    {
        ShapeBase incShapeBase = collision.gameObject.GetComponent<ShapeBase>();
        
        if (incShapeBase != null)
        {
            incShapeBase.Bounce(CalculateRandomness(incShapeBase));
        }
    }

    Vector2 CalculateRandomness(ShapeBase obj)
    {
        Vector2 rand = new Vector2();
        Vector2 direction = Vector2.up;
       
      //Read object and determine random range to throw object off hand
      //USE: obj.myShape to read type
      /*
        Sphere = Some randomness 
        Cube = little to no randomness 
        Bounce = High randomness
      */
      switch (obj.myShape)
      {
          case Shape.Sphere:
              rand.x = Random.Range(0f, 0.5f);
              rand.y = Random.Range(0f, 0.5f);
              break;
          case Shape.Cube:
              rand.x = Random.Range(0f, 0.2f);
              rand.y = Random.Range(0f, 0.2f);
              break;
          case Shape.Bouncer:
              rand.x = Random.Range(0f, 1f);
              rand.y = Random.Range(0f, 1f);
              break;
      }

      direction += rand;
      return direction;
    }
}
