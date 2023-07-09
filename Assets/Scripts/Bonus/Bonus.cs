using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bonus : MonoBehaviour
{

    //Used to test if the coroutines is already executing
    private bool isCoroutineExecuting = false;

    /***
    Make the bonus disappear after 6 seconds.
    @param time : amount of seconds.
    ***/
    protected void ShowAndHide(float time) {
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
}
