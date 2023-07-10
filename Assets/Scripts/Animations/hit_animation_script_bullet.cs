using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hit_animation_script_bullet : StateMachineBehaviour
{

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        FindObjectOfType<AudioManager>().Play("Explosion");
        Rigidbody2D rigidbody = animator.gameObject.GetComponent<Rigidbody2D>();
        rigidbody.constraints = RigidbodyConstraints2D.FreezePosition;
        rigidbody.constraints = RigidbodyConstraints2D.FreezeRotation;
        Destroy(animator.gameObject, stateInfo.length);
    }
}