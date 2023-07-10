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
        SceneManager.LoadScene("Story");
    }

    /***
    Start the game in endless mode upon clicking an endless button.
    ***/
    public void StartEndless(){
        FindObjectOfType<AudioManager>().Play("Button");
        SceneManager.LoadScene("Endless");
    }

    /***
    Restart the game upon clicking a restart button in the mode that was previously chosen by the player.
    ***/
    public void RestartGame(){
        FindObjectOfType<AudioManager>().Play("Button");
        int currentMode = PlayerPrefs.GetInt("Mode", 0);
        if(currentMode == 0) SceneManager.LoadScene("Story");
        else SceneManager.LoadScene("Endless");
    }

    /***
    Open main menu upon clicking the related button.
    ***/
    public void MainMenu(){
        FindObjectOfType<AudioManager>().Play("Button");
        SceneManager.LoadScene("Menu");
    }
}
