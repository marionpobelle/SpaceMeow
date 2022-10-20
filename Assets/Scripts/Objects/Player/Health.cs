using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    //Reference to player
    public GameObject player;

    //Reference to health bar aspect
    private Image healthBar;

    //Reference to PlayerBehavior
    public PlayerBehavior playerB;

    /***
    Start is called before the first frame update.
    ***/
    void Start(){
        healthBar = GetComponent<Image>();
        player = GameObject.FindGameObjectWithTag("Player");
        playerB = player.GetComponent<PlayerBehavior>();
    }

    /***
    FixedUpdate has the frequency of the physics system; it is called every fixed frame-rate frame.
    ***/
    void FixedUpdate(){
        //Update with player HP
        healthBar.fillAmount = playerB.barFill();
    }
}
