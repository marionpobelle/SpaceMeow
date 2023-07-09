using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarTrigger : Bonus
{
    //Reference to player
    GameObject player;

    //Reference to PlayerBehavior
    PlayerBehavior playerBehavior;


    /***
    Start is called before the first frame update.
    ***/
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerBehavior = player.GetComponent<PlayerBehavior>();
        ShowAndHide(6f);                                          
    }

    /***
    Behavior upon collision.
    -Player
    @param other : a collider.
    ***/
    void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.tag == "Player") {  
            //Play button sound
            FindObjectOfType<AudioManager>().PlayOneShot("Star");
            playerBehavior.anim.SetTrigger("Player_Star");   
            playerBehavior.Invulnerability(5f, true);
            //Destroy Object
            Destroy(gameObject);
        }
    }
}
