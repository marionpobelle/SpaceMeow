using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndScreenButtons : MonoBehaviour
{
    /***    
    Quit the game upon clicking a quit button. 
    ***/
    public void Quit(){
        FindObjectOfType<AudioManager>().Play("Button");
        Application.Quit();
    }
    
    /***    
    Resets the highscore, for test purposes 
    ***/
    public void ResetHighscore(){
         PlayerPrefs.DeleteKey("HighScore");
         PlayerPrefs.DeleteKey("Score");
    }

    /***
    Start the game upon clicking a start game button.
    ***/
    public void StartGame(){
        FindObjectOfType<AudioManager>().Play("Button");
        SceneManager.LoadScene("Game");
    }

    /***
    Open main menu upon clicking the related button.
    ***/
    public void MainMenu(){
        FindObjectOfType<AudioManager>().Play("Button");
        SceneManager.LoadScene("Menu");
    }
}
