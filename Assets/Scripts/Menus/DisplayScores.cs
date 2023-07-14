using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DisplayScores : MonoBehaviour
{
    //Text displayed on canvas
    public TextMeshProUGUI scoreText;

    //Current mode
    public int currentMode;

    void Start()
    {
        currentMode = PlayerPrefs.GetInt("Mode", 0);
    }

    /***
    Update is called every frame, if the MonoBehaviour is enabled.
    ***/
    void Update(){   
        float highScore = PlayerPrefs.GetInt("HighScore", 0);
        float score = PlayerPrefs.GetInt("Score", 0);

        float lowestTimeNumber;

        if(currentMode == 0)
        {
            lowestTimeNumber = PlayerPrefs.GetFloat("LowestTimeStory", 0);
        }
        else
        {
            lowestTimeNumber = PlayerPrefs.GetFloat("LowestTimeEndless", 0);
        }
        float time = PlayerPrefs.GetFloat("CurrentTime", 0);
        string lowestTime;
        if(lowestTimeNumber == 0) lowestTime = "NONE";
        else lowestTime = lowestTimeNumber.ToString("0");


        string finalDisplay = "current score : " + score.ToString("0") + " " + "highscore : " + highScore.ToString("0")
        + "     " + "lowest timer : " + lowestTime;
        scoreText.SetText(finalDisplay);
    }
}
