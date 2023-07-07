using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Life : MonoBehaviour
{

    //Reference to health bar aspect
    private Image lifeBar;

    //Current lifes
    public float lifes;

    //Number of Life
    public int maxLifes = 3;

    /***
    Start is called before the first frame update.
    ***/
    void Start()
    {
        lifes = maxLifes;
        lifeBar = GetComponent<Image>();
    }

    /***
    Update is called every frame, if the MonoBehaviour is enabled.
    ***/
    void Update()
    {
        //Update with player Lifes
        lifeBar.fillAmount = LifeFill();
    }

    /***
    Compute the current lifes for the life bar.
    ***/
    public float LifeFill(){
        return lifes / maxLifes;
    }

    /***
    Lower the lifes by 1.
    ***/
    public void LowerLifes(){
        lifes = lifes - 1;
    }
}
