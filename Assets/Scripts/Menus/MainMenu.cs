using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{

    public TMPro.TMP_Dropdown dropdown;

    /***
    Makes sure the displayed dropdown value is the state of the screen.
    ***/
    void Awake(){
        if(Screen.fullScreen == true) dropdown.value = 0;
        else if(Screen.fullScreen == false) dropdown.value = 1;
    }

}
