using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarTrigger : MonoBehaviour
{
    //Reference to player
    GameObject player;

    //Reference to PlayerBehavior
    PlayerBehavior playerB;


    /***
    Start is called before the first frame update.
    ***/
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerB = player.GetComponent<PlayerBehavior>();
        ShowAndHide(6f);                                          
    }

    //Used to test if the coroutines is already executing
    private bool isCoroutineExecuting = false;

    /***
    Make the HP bonus disappear after 6 seconds.
    @param time : amount of seconds.
    ***/
    private void ShowAndHide(float time) {
        StartCoroutine(ShowAndHideDelay(time));
    }
    /***
    Create a subroutine that make the bonus disappear after a certain amount of seconds
    @param delay : amount of seconds.
    ***/
    IEnumerator ShowAndHideDelay(float delay)
     {
        if (isCoroutineExecuting) yield break;
        isCoroutineExecuting = true;
        yield return new WaitForSeconds(delay);
        isCoroutineExecuting = false;
        Destroy(gameObject);
     }

    /***
    Behavior upon collision.
    -Player
    @param other : a collider.
    ***/
    void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.tag == "Player") {  
            //Play button sound
            FindObjectOfType<AudioManager>().PlayOneShot("Star");
            playerB.anim.SetTrigger("Player_Star");   
            playerB.Invulnerability(5f, true);
            //Destroy Object
            Destroy(gameObject);
        }
    }
}
