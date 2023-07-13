using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JellyfishBullet : MonoBehaviour
{

    //Jellyfish attack speed
    public float speed = 8f;

    //Reference to Game manager
    public GameManager gameManager;

     //Reference to the player HP bar
    public GameObject HPbar;

    //Reference to the player life bar
    public GameObject lifeBar;

    //Animator for the jellyfish attack
    public Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 6);
        HPbar = GameObject.FindGameObjectWithTag("HPBAR");
        lifeBar = GameObject.FindGameObjectWithTag("LIFEBAR");
        gameManager = FindObjectOfType<GameManager>();
    }

    /***
    Behavior upon collision.
    -Meteors
    -Player
    @param other : a collider.
    ***/
    void OnTriggerEnter2D(Collider2D other) {
        //If Object collides with a meteor
        if(other.gameObject.tag == "Enemy"){
            if(other.name == "BigMeteor"){
                other.GetComponent<BigMeteorBehavior>().animDest();
                FindObjectOfType<AudioManager>().Play("MeteorHit");
                anim.SetTrigger("hit");                 
            }
            else if(other.name == "TinyMeteor"){
                other.GetComponent<SmallMeteorBehavior>().animDest();
                FindObjectOfType<AudioManager>().Play("MeteorHit");
                anim.SetTrigger("hit");
            }
        }
        else if(other.gameObject.tag == "Player"){
            anim.SetTrigger("hit");
            if(HPbar.GetComponent<Health>().HP > 0){
                    HPbar.GetComponent<Health>().LowerHP(1);
                    if(HPbar.GetComponent<Health>().HP <= 0){ 
                        //If we lose all of our HP we lose a life
                        lifeBar.GetComponent<Life>().LowerLifes();
                        if(lifeBar.GetComponent<Life>().lifes <= 0) {
                            Debug.Log("Game is lost !");
                            gameManager.gameLost();
                        }
                        else{
                            other.GetComponent<PlayerBehavior>().death_anim = true;
                            other.GetComponent<PlayerBehavior>().Invulnerability(3f, false);
                            other.GetComponent<PlayerBehavior>().anim.SetTrigger(name: "Player_Dead");
                        }
                    }
                    else{
                        other.GetComponent<PlayerBehavior>().Invulnerability(2f, false);
                        FindObjectOfType<ArrowBehavior>().Pulse();
                        FindObjectOfType<AudioManager>().Play("DamageTaken");
                        other.GetComponent<PlayerBehavior>().rigidbodyPlayer.constraints = RigidbodyConstraints2D.None;
                        other.GetComponent<PlayerBehavior>().rigidbodyPlayer.constraints = RigidbodyConstraints2D.FreezeRotation;
                    }
            }
        }
    }

}
