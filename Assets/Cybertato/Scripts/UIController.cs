using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This script will be attached to an object on the player hand
/// will control the information displayed only
/// score, combo counter all read from the game manager
/// </summary>
public class UIController : MonoBehaviour
{
    private GameController gm;
    
    // Start is called before the first frame update
    void Start()
    {
        gm = FindObjectOfType<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
