using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, IPlayer
{
    public GameObject[] PlayerHands;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<ShapeBase>())
        {
            CalculateRandomness(collision.gameObject.GetComponent<ShapeBase>());
        }
    }

    Vector2 CalculateRandomness(ShapeBase obj)
    {
        
        Vector2 direction = Vector2.up;
       
      //Read object and determine random range to throw object off hand
      //USE: obj.myShape to read type
      /*
        Sphere = little to no randomness
        Cube = Some randomness
        Bounce = High randomness
      */

      return direction;
    }
}
