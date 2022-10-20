using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wave_anim_script : StateMachineBehaviour
{
    //Reference to bubble
    public GameObject Bubble;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       Destroy(animator.gameObject, stateInfo.length);
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Destroy(Bubble);
    }
}
