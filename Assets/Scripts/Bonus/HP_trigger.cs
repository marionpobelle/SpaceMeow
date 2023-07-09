using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HP_trigger : Bonus
{
    //Reference to the HP bar
    public GameObject HPbar;

    /***
    Start is called before the first frame update.
    ***/
    void Start()
    {
        HPbar = GameObject.FindGameObjectWithTag("HPBAR");
        ShowAndHide(6f);                                          
    }

    /***
    Behavior upon collision.
    -Player
    @param other : a collider.
    ***/
    void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.tag == "Player") {  
            FindObjectOfType<AudioManager>().Play("HPup");   
            if(HPbar.GetComponent<Health>().HP < HPbar.GetComponent<Health>().maxHealth) HPbar.GetComponent<Health>().IncreaseHP(1);
            Destroy(gameObject);
        }
    }
}
