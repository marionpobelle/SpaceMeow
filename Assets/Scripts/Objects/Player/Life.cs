using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Life : MonoBehaviour
{

    //Reference to health bar aspect
    private Image lifeBar;

    //Reference to player
    public GameObject player;

    //Reference to PlayerBehavior
    public PlayerBehavior playerB;

    /***
    Start is called before the first frame update.
    ***/
    void Start()
    {
        lifeBar = GetComponent<Image>();
        player = GameObject.FindGameObjectWithTag("Player");
        playerB = player.GetComponent<PlayerBehavior>();
    }

    /***
    Update is called every frame, if the MonoBehaviour is enabled.
    ***/
    void Update()
    {
        //Update with player Lifes
        lifeBar.fillAmount = playerB.lifeFill();
    }
}
