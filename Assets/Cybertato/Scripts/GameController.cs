using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Liminal.Core.Fader;
using Liminal.SDK.Core;
using Unity.Collections;

public class GameController : MonoBehaviour
{
    #region Editor Debug
    
    [HideInInspector]
    public float waitTime;

    private void Update()
    {
        waitTime -= Time.deltaTime;
        Mathf.Round(waitTime);
    }
    #endregion

    public int score { get; private set; }
    public int scoreMultiplier { get; private set; }
    private int comboCounter;

    [Header("SETUP VARIABLES")]
    public Spawner spawner;
    
    [Header("ADJUSTABLE VARIABLES")]
    [Tooltip("Length of time the experience will go for")]
    public float timer = 10.0f;

    public DifficultyStage[] experienceStages;
    private DifficultyStage currentStage;

    private void Start()
    {
        StartCoroutine(ExperienceTimer(timer));

        spawner.maxObjs = 0;
        StartCoroutine(BeginStage(timer));
    }

    public void AddScore()
    {
        comboCounter++;
        if (comboCounter%5 == 0)
        {
            scoreMultiplier++;
        }
        
        score += scoreMultiplier;
        
        if(score >= currentStage.bonusScore)
            spawner.SpawnGivenObject(currentStage.bonusShape);
    }

    public void ResetCombo()
    {
        scoreMultiplier = 1;
        comboCounter = 0;
    }

    IEnumerator BeginStage(float delay)
    {
        //start at stages[0]
        //read number of shapes to spawn
        //set spawner limit to 1+ that to allow for bonus shape
        //spawn obj1
        //wait for wait for (1/3 total time)/number of objects
        //spawn obj2
        //wait for remaining time

        //Should be generic enough to work for each stage and varying array sizes.....

        delay /= experienceStages.Length;
        foreach (DifficultyStage stage in experienceStages)
        {
            currentStage = stage;

            delay /= stage.mainShapes.Length;
            spawner.maxObjs += stage.mainShapes.Length + 1;

            foreach (ShapeBase shape in stage.mainShapes)
            {
                waitTime = delay;
                
                spawner.SpawnGivenObject(shape);
                yield return new WaitForSeconds(delay);
            }
        }
    }
    
    private IEnumerator ExperienceTimer(float delay)
    {
        
        yield return new WaitForSeconds(delay);
        GoodWayToEnd();
    
    }
    
    
    private void GoodWayToEnd() //This is all from the SDK documentation
    {
        StartCoroutine(FadeAndExit(2f));

        // This coroutine fades the camera and audio simultaneously over the same length of time.
        IEnumerator FadeAndExit(float fadeTime)
        {
            var elapsedTime = 0f; //instantiate a float with a value of 0 for use as a timer.
            var startingVolume = AudioListener.volume; //this gets the current volume of the audio listener so that we can fade it to 0 over time.

            ScreenFader.Instance.FadeTo(Color.black, fadeTime); // Tell the system to fade the camera to black over X seconds where X is the value of fadeTime.

            while (elapsedTime < fadeTime)
            {
                elapsedTime += Time.deltaTime; // Count up
                AudioListener.volume = Mathf.Lerp(startingVolume, 0f, elapsedTime / fadeTime); // This uses linear interpolation to change the volume of AudioListener over time.
                yield return new WaitForEndOfFrame(); // Tell the coroutine to wait for a frame to avoid completing this loop in a single frame.
            }

            // when the while-loop has ended, the audiolistener volume should be 0 and the screen completely black. However, for safety's sake, we should manually set AudioListener volume to 0.
            AudioListener.volume = 0f;

            ExperienceApp.End(); // This tells the platform to exit the experience.

        }
    }
}
    

