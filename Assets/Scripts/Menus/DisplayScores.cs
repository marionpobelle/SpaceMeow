using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DisplayScores : MonoBehaviour
{
    //Text displayed on canvas
    public TextMeshProUGUI scoreText;

    /***
    Update is called every frame, if the MonoBehaviour is enabled.
    ***/
    void Update(){   
        float highScore = PlayerPrefs.GetInt("HighScore");
        float score = PlayerPrefs.GetInt("Score");
        string finalDisplay = "current score : " + score.ToString("0") + " " + "highscore : " + highScore.ToString("0");
        scoreText.SetText(finalDisplay);
    }
}
