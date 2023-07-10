using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    //Reference to the controls menu
    public ControlsMenu controlsMenu;

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
    Quit the game upon clicking a quit button. 
    ***/
    public void Quit(){
        FindObjectOfType<AudioManager>().Play("Button");
        Application.Quit();
    }

    /***    
    Opens the controls menu. 
    ***/
    public void Controls(){
        FindObjectOfType<AudioManager>().Play("Button");
        controlsMenu.Open();
    }

    /***    
    Sets key binding to AZERTY. 
    ***/
    public void SetAzerty(){
        FindObjectOfType<AudioManager>().Play("Button");
        PlayerPrefs.SetInt("KeyBinding", 0);
        PlayerPrefs.Save();
    }

    /***    
    Sets key binding to QWERTY. 
    ***/
    public void SetQwerty(){
        FindObjectOfType<AudioManager>().Play("Button");
        PlayerPrefs.SetInt("KeyBinding", 1);
        PlayerPrefs.Save();
    }

    /***    
    Sets screen to full screen or windowed. 
    ***/
    public void SetScreen(int value){
        if(value == 0){
            Screen.fullScreen = true;
        }
        else if(value == 1){
            Screen.fullScreen = false;
        }
    }
}
