using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LosingManager : MonoBehaviour
{
    //Last saved highscore
    int lastHighscore;

    /***
    Start is called before the first frame update.
    ***/
    void Start()
    {   
        FindObjectOfType<AudioManager>().Play("LosingScreen");
        int highscore = PlayerPrefs.GetInt("HighScore");
        lastHighscore = PlayerPrefs.GetInt("LastHighscore", 0);
        if(highscore > lastHighscore){
            FindObjectOfType<AudioManager>().Play("NewHighscore");
            PlayerPrefs.SetInt("LastHighscore", highscore);
            PlayerPrefs.Save();
        }
    }
}