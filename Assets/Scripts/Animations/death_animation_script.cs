using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class death_animation_script : StateMachineBehaviour
{

    //Reference to player
    public GameObject player;

    //OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        FindObjectOfType<AudioManager>().Play("PlayerDeath");
    }

    //OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.FindGameObjectWithTag("Player");
        Rigidbody2D rigidbody = player.GetComponent<Rigidbody2D>();
        rigidbody.constraints = RigidbodyConstraints2D.FreezePosition;
        rigidbody.constraints = RigidbodyConstraints2D.FreezeRotation;
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.FindGameObjectWithTag("Player");
        Rigidbody2D rigidbody = player.GetComponent<Rigidbody2D>();
        PlayerBehavior playerBehavior = player.GetComponent<PlayerBehavior>();
        playerBehavior.ResetPlayer();
        rigidbody.constraints = RigidbodyConstraints2D.None;
        rigidbody.constraints = RigidbodyConstraints2D.FreezeRotation;
        playerBehavior.death_anim = false;
    }
}
