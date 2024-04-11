﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHand : MonoBehaviour
{

    [Header("SETUP VARIABLES")]
    [Tooltip("Add the collider of THIS INSTANCE of the Player Hand")]
    public Collider myCollider;
    public event Action<Collider, Collision> hitEvent;

    AudioSource SFX;

    private void Start()
    {
        SFX = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        hitEvent?.Invoke(myCollider, collision);
        SFX.Play();
    }
}
