using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LosingManager : MonoBehaviour
{
    //Last saved highscore
    int lastSavedHighscore;

    //Indicate the current mode : 0 for story, 1 for endless;
    int currentMode;

    //Indicate if the boss was defeated : 0 for no, 1 for yes;
    int bossIsDefeated;

    /***
    Start is called before the first frame update.
    ***/
    void Start()
    {   
        currentMode = PlayerPrefs.GetInt("Mode", 0);
        bossIsDefeated = PlayerPrefs.GetInt("bossDefeated", 0);
        FindObjectOfType<AudioManager>().Play("LosingScreen");
        if(currentMode == 1){
            int highscore = PlayerPrefs.GetInt("HighScore");
            lastSavedHighscore = PlayerPrefs.GetInt("LastHighscore", 0);
            if(highscore > lastSavedHighscore){
                FindObjectOfType<AudioManager>().PlayOneShot("NewHighscore");
                PlayerPrefs.SetInt("LastHighscore", highscore);
                PlayerPrefs.Save();
            }
        }else if(currentMode == 0){
            if(bossIsDefeated == 1){
                PlayerPrefs.SetInt("bossDefeated", 0);
                FindObjectOfType<AudioManager>().Play("GameWon");
                int highscore = PlayerPrefs.GetInt("HighScore");
                lastSavedHighscore = PlayerPrefs.GetInt("LastHighscore", 0);
                if(highscore > lastSavedHighscore){
                    PlayerPrefs.SetInt("LastHighscore", highscore);
                    PlayerPrefs.Save();
                }
            }
            else{
                FindObjectOfType<AudioManager>().Play("GameLost");
                int highscore = PlayerPrefs.GetInt("HighScore");
                lastSavedHighscore = PlayerPrefs.GetInt("LastHighscore", 0);
                if(highscore > lastSavedHighscore){
                    PlayerPrefs.SetInt("LastHighscore", highscore);
                    PlayerPrefs.Save();
                }
            }
        }
    }
}