using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateManagerBigMeteor : MonoBehaviour
{
    //Displaying sprite for low health
    public Sprite lowHealth; 

    //Displaying sprite for medium health
    public Sprite mediumHealth; 

    //Displaying sprite for full health.
    public Sprite fullHealth; 

    //This represent the current health.
    int currentHealth;
 
    //Big meteor's sprite renderer
    private SpriteRenderer spriteRenderer;

    //Reference to a big meteor's behavior
    BigMeteorBehavior bigMeteorBehavior;

    /***
    Start is called before the first frame update
    ***/
    private void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        bigMeteorBehavior = gameObject.GetComponent<BigMeteorBehavior>();
    }
    
    /***
    FixedUpdate has the frequency of the physics system; it is called every fixed frame-rate frame.
    ***/
    private void FixedUpdate()
    {
        currentHealth = bigMeteorBehavior.GetHP();
        SetSprite();
    }
    
    /***
    Change the object's sprite based on its HP.
    ***/
    private void SetSprite ()
    {
        if (currentHealth < 2){
            spriteRenderer.sprite = lowHealth;
        }
        else if(currentHealth < 4){
            spriteRenderer.sprite = mediumHealth;
        }
        else{
            spriteRenderer.sprite = fullHealth;
        }
    }
}
