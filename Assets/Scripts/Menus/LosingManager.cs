using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LosingManager : MonoBehaviour
{
    //Last saved highscore
    int lastSavedHighscore;

    /***
    Start is called before the first frame update.
    ***/
    void Start()
    {   
        FindObjectOfType<AudioManager>().Play("LosingScreen");
        int highscore = PlayerPrefs.GetInt("HighScore");
        lastSavedHighscore = PlayerPrefs.GetInt("LastHighscore", 0);
        if(highscore > lastSavedHighscore){
            FindObjectOfType<AudioManager>().Play("NewHighscore");
            PlayerPrefs.SetInt("LastHighscore", highscore);
            PlayerPrefs.Save();
        }
    }
}