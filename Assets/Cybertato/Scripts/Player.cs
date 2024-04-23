using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Player : MonoBehaviour, IPlayer
{
    [Header("SETUP VARIABLES")]
    [Tooltip("Must include all \"PlayerHand\" instances")]
    public PlayerHand[] PlayerHands;

    private GameController gm;

    private void Start()
    {
        gm = FindObjectOfType<GameController>();
    }

    private void OnEnable()
    {
        foreach (PlayerHand hand in PlayerHands)
        {
            hand.hitEvent += HandCollisionHit;
        }
    }

    private void HandCollisionHit(Collider handCollider, Collision incCollision)
    {
        ShapeBase incShapeBase = incCollision.gameObject.GetComponent<ShapeBase>();
        
        if (incShapeBase != null)
        {
            incShapeBase.Bounce(CalculateRandomness(handCollider, incShapeBase));
            gm.AddScore();
        }
    }

    Vector3 CalculateRandomness(Collider handCollider, ShapeBase obj)
    {
        Vector3 rand = new Vector3();
        Vector3 direction = handCollider.transform.up;
       
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
          case Shape.Pyramid:
              rand.x = Random.Range(0f, 1f);
              rand.y = Random.Range(0f, 1f);
              break;
      }

      direction += rand;
      return direction;
    }
}
