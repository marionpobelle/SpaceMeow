using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FinalScore : MonoBehaviour
{

    //Current mode
    public int currentMode;
    //Text displayed on canvas
    public TextMeshProUGUI scoreText;

    void Start()
    {
        currentMode = PlayerPrefs.GetInt("Mode", 0);
    }

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
        string finalDisplay = "current score : " + score.ToString("0") + "\r\n" + "highscore : " + highScore.ToString("0")
        + "\r\n" + "current timer : " + time.ToString("0") + "\r\n" + "lowest timer : " + lowestTime;
        scoreText.SetText(finalDisplay);
    }
}

