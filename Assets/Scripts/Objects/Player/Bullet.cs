using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    //Animation upon collision
    public Animator anim;
    public GameObject hitEffect;
    
    //Reference to game manager
    public GameManager gm;
    
    /***
    Awake is called when the script instance is being loaded.
    ***/
    void Awake()
    {
        gm = FindObjectOfType<GameManager>();
    }

    /***
    Behavior upon collision.
    -Meteors
    @param other : a collider.
    ***/
    void OnTriggerEnter2D(Collider2D other) {
        //If Object collides with a meteor
        if(other.gameObject.tag == "Enemy"){
            int meteorHP;
            if(other.name == "BigMeteor"){
                other.GetComponent<BigMBehavior>().lowerHP();
                meteorHP = other.GetComponent<BigMBehavior>().GetHP();
                if(meteorHP <= 0){
                    gm.IncreaseBigScore();
                    other.GetComponent<BigMBehavior>().animDest();
                }else{
                    FindObjectOfType<AudioManager>().Play("MeteorHit");
                    anim.SetTrigger("hit");
                }
                    
            }
            else if(other.name == "TinyMeteor"){
                other.GetComponent<SmallMBehavior>().lowerHP();
                meteorHP = other.GetComponent<SmallMBehavior>().GetHP();
                if(meteorHP <= 0){
                        gm.IncreaseScore();
                        other.GetComponent<SmallMBehavior>().animDest();
                    }else{
                        FindObjectOfType<AudioManager>().Play("MeteorHit");
                        anim.SetTrigger("hit");
                    }
            }
        }
    }

    /***
    Behavior upon leaving screen view.
    Delete Object to save space.
    ***/
    void OnBecameInvisible(){
        Destroy(gameObject);
    }

}
