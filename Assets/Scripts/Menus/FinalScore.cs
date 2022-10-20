using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FinalScore : MonoBehaviour
{

    //Text displayed on canvas
    public TextMeshProUGUI scoreText;

    void Update(){   
        float highScore = PlayerPrefs.GetInt("HighScore");
        float score = PlayerPrefs.GetInt("Score");
        string final = "current score : " + score.ToString("0") + " " + "highscore : " + highScore.ToString("0");
        scoreText.SetText(final);
    }
}

