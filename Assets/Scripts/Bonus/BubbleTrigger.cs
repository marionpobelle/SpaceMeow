using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleTrigger : Bonus
{
    //Reference to player
    GameObject player;

    //Reference to PlayerBehavior
    PlayerBehavior playerB;

    //Bubble animation
    public Animator anim;


    /***
    Start is called before the first frame update.
    ***/
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerB = player.GetComponent<PlayerBehavior>();
        ShowAndHide(6f);                                          
    }

    /***
    Behavior upon collision.
    -Player
    @param other : a collider.
    ***/
    void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.tag == "Player") {  
            anim.SetTrigger("wave"); 
            FindObjectOfType<AudioManager>().Play("Bubble"); 
            GameObject[] objects = GameObject.FindGameObjectsWithTag("Enemy");
            int objectCount = objects.Length;
            for(int i=0; i<objectCount;i++){
                if(objects[i].name == "BigMeteor") objects[i].GetComponent<BigMBehavior>().animDest();
                if(objects[i].name == "TinyMeteor") objects[i].GetComponent<SmallMBehavior>().animDest();
            }
        }
    }
}
