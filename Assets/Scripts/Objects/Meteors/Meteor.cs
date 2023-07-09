using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteor : MonoBehaviour
{
   //Object rigidbody2D
    public Rigidbody2D rigidbodyMeteor;
    
    //Direction speed
    protected float speed;

    //Maximum speed
    public float max_speed;

    //Object HP
    public int HP;

    //Meteor animator
    public Animator anim;

    //Meteor damage
    public int damage;

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
