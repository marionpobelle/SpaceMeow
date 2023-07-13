using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallMeteorBehavior : Meteor
{

    //Offset so the object spawn going +-towards the player
    public float directionOffset;

    //Reference to the player
    GameObject player;

    //Object direction
    Vector2 mainDirection;

    /***
    Start is called before the first frame update.
    ***/
    void Start(){
        damage = 1;
        player = GameObject.FindGameObjectWithTag("Player");
        Rigidbody2D rigidbodyPlayer = player.GetComponent<Rigidbody2D>();
        Vector2 directionTowardPlayer = rigidbodyPlayer.position - rigidbodyMeteor.position;
        mainDirection = rigidbodyPlayer.position - rigidbodyMeteor.position;
        mainDirection[0] = mainDirection[0] + (Random.Range(0,2)*2-1) * directionOffset * mainDirection[0];
        //Random starting speed
        speed = Random.Range(1000f, 2500f);
        rigidbodyMeteor.AddForce(directionTowardPlayer * speed * Time.deltaTime, ForceMode2D.Impulse);
    }

    /***
    FixedUpdate has the frequency of the physics system; it is called every fixed frame-rate frame.
    ***/
    void FixedUpdate(){
        if(Mathf.Abs(rigidbodyMeteor.angularVelocity) < max_speed) {
            //Push Object in his current direction
            rigidbodyMeteor.AddForce( mainDirection *speed * Time.deltaTime, ForceMode2D.Impulse);
        }
    }

    /***
    Behavior upon collision.
    -Meteors
    -Player
    -Boss
    @param collision : a collision
    ***/
    void OnCollisionEnter2D(Collision2D collision) {
        if(collision.collider.tag == "Enemy") {
            //Push Object in the opposite direction (prevents asteroids from getting stuck to each others)
            rigidbodyMeteor.AddForce( - mainDirection *speed * Time.deltaTime, ForceMode2D.Impulse);
        }
        if(collision.collider.tag == "Player") {
            animDest();
        }
        if(collision.collider.tag == "Boss") {
            animDest();
        }
    }

}
