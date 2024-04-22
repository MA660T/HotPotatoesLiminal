﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

/// <summary>
/// This script will be attached to an object on the player hand
/// will control the information displayed only
/// score, combo counter all read from the game manager
/// </summary>
public class UIController : MonoBehaviour
{
    [Header("SETUP VARIABLES")]
    [Tooltip("Only Instance of \"GameController\" in scene ")]
    public GameController gm;
    private TMP_Text ScoreText;

    
    // Start is called before the first frame update
    void Start()
    {
        ScoreText = GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
