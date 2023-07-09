using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    //Player animator
    public Animator anim;

    //Player polygonCollider2D
    public PolygonCollider2D pc2d;

    //Player rigidbody2D
    public Rigidbody2D rb;

    //Main camera
    public Camera cam;

    //Player move speed
    float moveSpeed = 5;

    //Reference to Game manager
    public GameManager gm;

    //Reference to the HP bar
    public GameObject HPbar;

    //Reference to the fife bar
    public GameObject lifeBar;

    //Impulse given after hitting a side of the screen
    float sideScreenImpulsion = 10;

    //Indicate if the death animation is playing
    public bool death_anim = false;

    //Indicate the key bindings used by the player
    int keybinding;

    void Start() {
        keybinding = PlayerPrefs.GetInt("KeyBinding", 1);
    }

    /***
    FixedUpdate has the frequency of the physics system; it is called every fixed frame-rate frame.
    ***/
    void FixedUpdate() {
        //QWERTY
        if(keybinding == 1){
            //Using Impulse to simulate space inertia
            if(Input.GetKey("w")) {
                rb.AddForce(new Vector2(0,moveSpeed * Time.deltaTime), ForceMode2D.Impulse);
            }
            if(Input.GetKey("s")) {
                rb.AddForce(new Vector2(0,-moveSpeed * Time.deltaTime), ForceMode2D.Impulse);
            }
            if(Input.GetKey("a")) {
                rb.AddForce(new Vector2(-moveSpeed * Time.deltaTime,0), ForceMode2D.Impulse);
            }
            if(Input.GetKey("d")) {
                rb.AddForce(new Vector2(moveSpeed * Time.deltaTime,0), ForceMode2D.Impulse);
            }
        //AZERTY
        }else{
            if(Input.GetKey("z")) {
                rb.AddForce(new Vector2(0,moveSpeed * Time.deltaTime), ForceMode2D.Impulse);
            }
            if(Input.GetKey("s")) {
                rb.AddForce(new Vector2(0,-moveSpeed * Time.deltaTime), ForceMode2D.Impulse);
            }
            if(Input.GetKey("q")) {
                rb.AddForce(new Vector2(-moveSpeed * Time.deltaTime,0), ForceMode2D.Impulse);
            }
            if(Input.GetKey("d")) {
                rb.AddForce(new Vector2(moveSpeed * Time.deltaTime,0), ForceMode2D.Impulse);
            }
        }
        //Holds the current position
        Vector3 playerPos = transform.position;
        //If player gets out of view screen, TP him back to the edge
        //and give him a tiny impulse towards the inside of the screen so he doesn't get stuck
        if(playerPos.x > gm.max_x){
            playerPos.x = gm.max_x;
            transform.position = playerPos;
            rb.AddForce(new Vector2(- moveSpeed * sideScreenImpulsion * Time.deltaTime, 0), ForceMode2D.Impulse);
        }
        if(playerPos.x < gm.min_x){
            playerPos.x = gm.min_x;
            transform.position = playerPos;
            rb.AddForce(new Vector2( moveSpeed * sideScreenImpulsion * Time.deltaTime, 0), ForceMode2D.Impulse);
        }
        if(playerPos.y > gm.max_y){
            playerPos.y = gm.max_y;
            transform.position = playerPos;
            rb.AddForce(new Vector2(0, - moveSpeed * sideScreenImpulsion * Time.deltaTime), ForceMode2D.Impulse);
        }
        if(playerPos.y < gm.min_y){
            playerPos.y = gm.min_y;
            transform.position = playerPos;
            rb.AddForce(new Vector2(0, moveSpeed * sideScreenImpulsion * Time.deltaTime), ForceMode2D.Impulse);
        }
    }

    /***
    Behavior upon trigger.
    -Meteors
    @param collision : a collision.
    ***/
    void OnCollisionEnter2D(Collision2D collision){
        rb.constraints = RigidbodyConstraints2D.FreezePosition;
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        if(collision.collider.tag == "Enemy") {
            Meteor meteor = collision.gameObject.GetComponent<Meteor>();
            if(meteor != null){
                if(HPbar.GetComponent<Health>().HP > 0){
                    HPbar.GetComponent<Health>().LowerHP(meteor.damage);
                    if(HPbar.GetComponent<Health>().HP <= 0){ 
                        //If we lose all of our HP we lose a life
                        lifeBar.GetComponent<Life>().LowerLifes();
                        if(lifeBar.GetComponent<Life>().lifes <= 0) {
                            Debug.Log("Game is lost !");
                            gm.gameLost();
                        }
                        else{
                            death_anim = true;
                            Invulnerability(3f, false);
                            anim.SetTrigger(name: "Player_Dead");
                        }
                    }
                    else{
                        Invulnerability(2f, false);
                        FindObjectOfType<ArrowBehavior>().Pulse();
                        FindObjectOfType<AudioManager>().Play("DamageTaken");
                        rb.constraints = RigidbodyConstraints2D.None;
                        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
                    }
                }
            }
        }  
    }

    /***
    Reset the player HP and position upon death.
    ***/
    public void ResetPlayer() {
        Vector3 playerPos = transform.position;
        playerPos.x = 0;
        playerPos.y = 0;
        transform.position = playerPos;
        HPbar.GetComponent<Health>().SetHPFull();
    }
    
    /***
    Check if the player is dying.
    ***/
    public bool GetDeath(){
        return death_anim;
    }

    /***
    Change the death status of the player.
    ***/
    public void ChangeDeath(){
        if(death_anim == false) death_anim = true;
        if(death_anim == true) death_anim = false;
    }

    //Used to test if the coroutines is already executing
    private bool isCoroutineExecuting = false;

    /***
    Create a window of invulnerability, used when hurt, respawn or bonus.
    @param time : amount of seconds.
    ***/
    public void Invulnerability(float time, bool star) {
        //We deactivate the polygonCollider2D to make the player intangible
        pc2d.enabled = false;
        //Call a subroutine to reactivate the polygonCollider2D
        StartCoroutine(InvulnerabilityDelay(time, star));
    }

    /***
    Create a subroutine to create a time where the player is intangible after being hit or grabbing a bonus.
    @param time : amount of seconds.
    ***/
    IEnumerator InvulnerabilityDelay(float time, bool star){
        if (isCoroutineExecuting) yield break;
        isCoroutineExecuting = true;
        yield return new WaitForSeconds(time/2);
        //Indicate that the bonus is ending with a sound cue
        if(star == true) FindObjectOfType<AudioManager>().PlayOneShot("StarReversed");
        yield return new WaitForSeconds(time/2);
        //Code to execute after the delay
        //Reactivate the hitbox
        pc2d.enabled = true;
        isCoroutineExecuting = false;
    }

}
