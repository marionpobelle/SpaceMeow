using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StateManagerTinyMeteor : MonoBehaviour
{
   //Displaying sprite for low health
   public Sprite lowHealth;

   //Displaying sprite for low health
   public Sprite fullHealth; 

   //This represent the current health.
   int currentHealth; 
 
   //Tiny meteor's sprite renderer
   private SpriteRenderer spriteRenderer;

   //Reference to a tiny meteor's behavior
   SmallMeteorBehavior smallMeteorBehavior;

   /***
    Start is called before the first frame update
    ***/
    private void Start()
   {
      spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
      smallMeteorBehavior = gameObject.GetComponent<SmallMeteorBehavior>();
     }
   
   /***
    FixedUpdate has the frequency of the physics system; it is called every fixed frame-rate frame.
    ***/
   private void FixedUpdate()
   {
      currentHealth = smallMeteorBehavior.GetHP();
      SetSprite();
   }
   
   /***
    Change the object's sprite based on its HP.
    ***/
   private void SetSprite ()
   {
      if (currentHealth < 2)
      {
         spriteRenderer.sprite = lowHealth;
      }
      else
      {
         spriteRenderer.sprite = fullHealth;
      }
   }
}
