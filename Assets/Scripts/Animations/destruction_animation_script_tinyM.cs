using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destruction_animation_script_tinyM : StateMachineBehaviour
{

    //Reference to tiny meteor
    public GameObject TinyMeteor;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        GameObject tinyRock = animator.gameObject;
        FindObjectOfType<AudioManager>().Play("Explosion");
        Rigidbody2D rb = tinyRock.GetComponent<Rigidbody2D>();
        BoxCollider2D box = tinyRock.GetComponent<BoxCollider2D>();
        box.enabled = false;
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        Destroy(animator.gameObject, stateInfo.length);
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       Destroy(TinyMeteor); 
    }
}
