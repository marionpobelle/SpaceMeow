using UnityEngine;

public class ControlsMenu : MonoBehaviour
{
    [SerializeField] GameObject controlsMenu;

    /***    
    Opens the controls menu. 
    ***/
    public void Open(){
            controlsMenu.SetActive(true);
    }

    /***    
    Closes the controls menu. 
    ***/
    public void Close(){
        FindObjectOfType<AudioManager>().Play("Button");
        controlsMenu.SetActive(false);
        
    }
}
