using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hit_animation_script_bullet : StateMachineBehaviour
{

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Debug.Log("enter");
        FindObjectOfType<AudioManager>().Play("Explosion");
        Rigidbody2D rb = animator.gameObject.GetComponent<Rigidbody2D>();
        rb.constraints = RigidbodyConstraints2D.FreezePosition;
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        Destroy(animator.gameObject, stateInfo.length);
    }
}