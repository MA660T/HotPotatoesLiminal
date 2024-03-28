using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, IPlayer
{
   public GameObject[] PlayerHands;

   public delegate void ObjectBounce(ShapeBase obj, Vector2 direction);
   public event ObjectBounce bounceEvent;

   void CalculateRandomness(ShapeBase obj)
   {
      //Read object and determine random range to throw object off hand
      //USE: obj.myShape to read type
      /*
        Sphere = little to no randomness
        Cube = Some randomness
        Bounce = High randomness
      */

      bounceEvent?.Invoke(obj, Vector2.zero);
   }
}
