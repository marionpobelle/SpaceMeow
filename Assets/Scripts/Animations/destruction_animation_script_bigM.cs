using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destruction_animation_script_bigM : StateMachineBehaviour
{

    //Reference to big meteor
    public GameObject BigMeteor;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Destroy(animator.gameObject, stateInfo.length);
        GameObject bigRock = animator.gameObject;
        FindObjectOfType<AudioManager>().Play("Explosion");
        Rigidbody2D rb = bigRock.GetComponent<Rigidbody2D>();
        BoxCollider2D box = bigRock.GetComponent<BoxCollider2D>();
        box.enabled = false;
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Destroy(BigMeteor);
    }
}
