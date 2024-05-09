using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreRead : MonoBehaviour
{
    public TMP_Text scoreText;
    public TMP_Text comboText;

    private int tempScore;
    private int tempCombo;

    // Start is called before the first frame update
    void Start()
    {
        scoreText.enabled = false;
        comboText.enabled = false;
    }

    public void ShowScore(int score, int combo)
    {
        //read final score from gm
        //read max combo from gm
        //do the number ramp up thing..... somehow in a function....
        StartCoroutine(UpdateScores(score, combo));
    }

    IEnumerator UpdateScores(int fScore, int maxCombo)
    {
        scoreText.enabled = true;
        while (tempScore < fScore)
        {
            tempScore++;
            scoreText.text = "Final Score: " + tempScore;

            yield return null;
        }
        comboText.enabled = true;
        while (tempCombo < maxCombo)
        {
            tempCombo++;
            comboText.text = "\n +\n Max Combo: " + tempScore;

            yield return null;
        }

        scoreText.text = "Final Score: " + fScore;
        comboText.text = "\n +\n Max Combo: " + maxCombo;
    }
}
