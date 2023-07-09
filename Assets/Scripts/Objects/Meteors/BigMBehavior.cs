using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigMBehavior : Meteor
{
    

    //Random initial directions
    int x_rd;
    int y_rd;

    //Object direction
    Vector2 mainDir;

    /***
    Start is called before the first frame update.
    ***/
    void Start(){
        damage = 2;
        x_rd = Random.Range(0,2)*2-1;
        y_rd = Random.Range(0,2)*2-1;
        //Random starting speed
        speed = Random.Range(1000f, 2000f);
        //Random starting direction
        Vector2 randomForce = new Vector2(speed*x_rd, speed*y_rd);
        rg.AddForce(randomForce, ForceMode2D.Impulse);
    }

    /***
    FixedUpdate has the frequency of the physics system; it is called every fixed frame-rate frame.
    ***/
    void FixedUpdate(){
        if(Mathf.Abs(rg.angularVelocity) < max_speed) {
            mainDir = new Vector2(speed*x_rd, speed*y_rd);
            //Push Object in his current direction
            rg.AddForce( mainDir * Time.deltaTime, ForceMode2D.Impulse);
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
            rg.AddForce(-mainDir * 10 * Time.deltaTime, ForceMode2D.Impulse);
        }
        if(collision.collider.tag == "Player") {
            animDest();
        }
    }

}