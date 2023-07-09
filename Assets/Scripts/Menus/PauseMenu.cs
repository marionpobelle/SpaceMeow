using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class PauseMenu : MonoBehaviour
{

    [SerializeField] GameObject pauseMenu;

    //Reference to Game manager
    public GameManager gameManager;

    //Reference to the audio mixer
    public AudioMixer audioMixer;

    /***
    Pauses the game.
    ***/
    public void Pause(){
        if(gameManager.isPaused() == true){
            return;
        }else{
            gameManager.pauseGame();
            pauseMenu.SetActive(true);
            FindObjectOfType<AudioManager>().Pause("Theme");
            FindObjectOfType<AudioManager>().Play("PauseMenu");
            Time.timeScale = 0f;
        }
    }

    /***
    Resumes the game.
    ***/
    public void Resume(){
        if(gameManager.isPaused() == true){
            gameManager.pauseGame();
            FindObjectOfType<AudioManager>().Play("Button");
            pauseMenu.SetActive(false);
            Time.timeScale = 1f;
            FindObjectOfType<AudioManager>().Stop("PauseMenu");
            FindObjectOfType<AudioManager>().UnPause("Theme");
        }else{
            return;
        }
        
    }

    /***
    Goes back to main menu.
    ***/
    public void Home(){
        //Need this so the music doesn't die
        Time.timeScale = 1f;
        FindObjectOfType<AudioManager>().Play("Button");
        SceneManager.LoadScene("Menu");
    }

    /***
    Set the overall volume.
    ***/
    public void SetVolume(float volume){
        audioMixer.SetFloat("volume", volume);
    }

    /***
    Set the music volume.
    ***/
    public void SetVolumeMusic(float volume){
        audioMixer.SetFloat("musicvolume", volume);
    }

    /***
    Set the sound effects volume.
    ***/
    public void SetVolumeSE(float volume){
        audioMixer.SetFloat("sevolume", volume);
    }
}
