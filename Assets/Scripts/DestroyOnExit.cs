using UnityEngine;

//Class connected to the animator.
public class DestroyOnExit : StateMachineBehaviour
{
    /***
    OnStateEnter is called when a transition starts and the state machine starts to evaluate this state.
    ***/
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        //Destroys animation after a set time
        //The time being the length of the animation so we remove it at the end
        Destroy(animator.gameObject, stateInfo.length);
    }
}
