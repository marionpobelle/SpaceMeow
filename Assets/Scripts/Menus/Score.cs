using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Score : MonoBehaviour
{
    //Reference to Game manager
    public GameManager gameManager;

    //Text displayed on canvas
    public TextMeshProUGUI scoreText;

    /***
    Update is called every frame, if the MonoBehaviour is enabled.
    ***/
    void Update(){   
        string finalDisplay = "score : " + gameManager.score.ToString("0");
        scoreText.SetText(finalDisplay);
    }
}
