using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHand : MonoBehaviour
{
    public Collider myCollider;
    public event Action<Collider, Collision> hitEvent;
    
    private void OnCollisionEnter(Collision collision)
    {
        hitEvent?.Invoke(myCollider, collision);
    }
}
