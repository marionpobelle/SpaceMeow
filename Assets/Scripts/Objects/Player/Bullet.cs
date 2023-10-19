using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    //Animation upon collision
    public Animator anim;
    public GameObject hitEffect;
    
    //Reference to game manager
    public GameManager gameManager;
    
    /***
    Awake is called when the script instance is being loaded.
    ***/
    void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    /***
    Behavior upon collision.
    -Meteors
    -Boss
    @param other : a collider.
    ***/
    void OnTriggerEnter2D(Collider2D other) {
        //If Object collides with a meteor
        if(other.gameObject.tag == "Enemy"){
            int meteorHP;
            if(other.name == "BigMeteor"){
                other.GetComponent<BigMeteorBehavior>().lowerHP();
                meteorHP = other.GetComponent<BigMeteorBehavior>().GetHP();
                if(meteorHP <= 0){
                    gameManager.IncreaseBigScore();
                    other.GetComponent<BigMeteorBehavior>().animDest();
                }else{
                    gameManager.IncreaseScoreHit();
                    FindObjectOfType<AudioManager>().Play("MeteorHit");
                    anim.SetTrigger("hit");
                }
                    
            }
            else if(other.name == "TinyMeteor"){
                other.GetComponent<SmallMeteorBehavior>().lowerHP();
                meteorHP = other.GetComponent<SmallMeteorBehavior>().GetHP();
                if(meteorHP <= 0){
                        gameManager.IncreaseScore();
                        other.GetComponent<SmallMeteorBehavior>().animDest();
                    }else{
                        gameManager.IncreaseScoreHit();
                        FindObjectOfType<AudioManager>().Play("MeteorHit");
                        anim.SetTrigger("hit");
                    }
            }
        }
        if(other.gameObject.tag == "Boss"){
            if(gameManager.isBossfightHappening == true){
                gameManager.bossHPbar.GetComponent<JellyfishHealth>().LowerHP(1);
                float bossHP = gameManager.bossHPbar.GetComponent<JellyfishHealth>().GetHP();
                if(bossHP <= 0){
                    gameManager.SetBossDead();
                    gameManager.StopBossfight();
                    other.GetComponent<JellyfishMovement>().BossDeathSequence();
                    Debug.Log("Boss is dead");
                        
                }else{
                    gameManager.IncreaseScoreHit();
                    FindObjectOfType<AudioManager>().Play("BossHit");
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
