using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Liminal.Core.Fader;
using Liminal.SDK.Core;

public class GameController : MonoBehaviour
{
    public int score { get; private set; }
    
    [Header("ADJUSTABLE VARIABLES")]
    [Tooltip("Length of time the experience will go for")]
    public float timer = 10.0f;

    private void Start()
    {
        //ExperienceTimer(timer);
    }

    public void AddScore()
    {
        score++;
    }
    
    private IEnumerator ExperienceTimer(float timer) {

        yield return new WaitForSeconds(timer);
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
    

