using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallMBehavior : MonoBehaviour
{
    //Object rigidbody2D
    public Rigidbody2D rg;

    //Direction speed
    float speed;

    //Maximum speed
    public float max_speed;

    //Object HP
    public int HP;

    //Offset so the object spawn going +-towards the player
    public float dirOffset;

    //Reference to the player
    GameObject player;

    //Object direction
    Vector2 mainDir;

    //Rock animator
    public Animator anim;

    /***
    Start is called before the first frame update.
    ***/
    void Start(){
        player = GameObject.FindGameObjectWithTag("Player");
        Rigidbody2D rgPlayer = player.GetComponent<Rigidbody2D>();
        Vector2 directionTowardPlayer = rgPlayer.position - rg.position;
        mainDir = rgPlayer.position - rg.position;
        mainDir[0] = mainDir[0] + (Random.Range(0,2)*2-1) * dirOffset * mainDir[0];
        //Random starting speed
        speed = Random.Range(1000f, 2500f);
        rg.AddForce(directionTowardPlayer * speed * Time.deltaTime, ForceMode2D.Impulse);
    }

    /***
    FixedUpdate has the frequency of the physics system; it is called every fixed frame-rate frame.
    ***/
    void FixedUpdate(){
        if(Mathf.Abs(rg.angularVelocity) < max_speed) {
            //Push Object in his current direction
            rg.AddForce( mainDir *speed * Time.deltaTime, ForceMode2D.Impulse);
        }
    }

    /***
    Behavior upon collision.
    -Meteors
    -Player
    @param collision : a collision
    ***/
    void OnCollisionEnter2D(Collision2D collision) {
        if(collision.collider.tag == "Enemy") {
            //Push Object in the opposite direction (prevents asteroids from getting stuck to each others)
            rg.AddForce( - mainDir *speed * Time.deltaTime, ForceMode2D.Impulse);
        }
        if(collision.collider.tag == "Player") {
            animDest();
        }
    }

    /***
    Behavior upon leaving screen view.
    Delete Object to save space.
    ***/
    void OnBecameInvisible(){
        Destroy(gameObject);
    }

    /***
    Lowers meteor HP.
    ***/
    public void lowerHP(){
        HP-=1;
    }

    /***
    Plays the destruction animation for the meteor.
    ***/
    public void animDest(){
        anim.enabled = true;
        anim.SetTrigger("destruction");
    }

    /***
    Gets meteor HP.
    ***/
    public int GetHP(){
        return HP;
    }

}
