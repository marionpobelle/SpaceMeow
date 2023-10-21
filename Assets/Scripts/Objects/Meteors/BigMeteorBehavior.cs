using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigMeteorBehavior : Meteor
{
    

    //Random initial directions
    int x_random;
    int y_random;

    //Object direction
    Vector2 mainDirection;

    /***
    Start is called before the first frame update.
    ***/
    void Start(){
        damage = 2;
        destScore = 5;
        x_random = Random.Range(0,2)*2-1;
        y_random = Random.Range(0,2)*2-1;
        //Random starting speed
        speed = Random.Range(1000f, 2000f);
        //Random starting direction
        Vector2 randomForce = new Vector2(speed*x_random, speed*y_random);
        rigidbodyMeteor.AddForce(randomForce, ForceMode2D.Impulse);
    }

    /***
    FixedUpdate has the frequency of the physics system; it is called every fixed frame-rate frame.
    ***/
    void FixedUpdate(){
        if(Mathf.Abs(rigidbodyMeteor.angularVelocity) < max_speed) {
            mainDirection = new Vector2(speed*x_random, speed*y_random);
            //Push Object in his current direction
            rigidbodyMeteor.AddForce( mainDirection * Time.deltaTime, ForceMode2D.Impulse);
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
            rigidbodyMeteor.AddForce(-mainDirection * 10 * Time.deltaTime, ForceMode2D.Impulse);
        }
        if(collision.collider.tag == "Player") {
            animDest();
        }
        if(collision.collider.tag == "Boss") {
            animDest();
        }
    }

}