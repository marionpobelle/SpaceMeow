using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{

    //Reference to Game manager
    public GameManager gameManager;

    //Text displayed on canvas
    public TextMeshProUGUI scoreText;

    /***
    Update is called every frame, if the MonoBehaviour is enabled.
    ***/
    void Update(){   
        string finalDisplay = "TIMER: " + gameManager.time.ToString("0") + "s";
        scoreText.SetText(finalDisplay);
    }
}
