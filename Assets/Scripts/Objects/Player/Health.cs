using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{

    //Reference to health bar aspect
    private Image healthBar;

    //Maximum HP
    public float maxHealth;

    //Current HP
    public float HP;

    /***
    Start is called before the first frame update.
    ***/
    void Start(){
        HP = maxHealth;
        healthBar = GetComponent<Image>();
    }

    /***
    FixedUpdate has the frequency of the physics system; it is called every fixed frame-rate frame.
    ***/
    void FixedUpdate(){
        //Update with player HP
        healthBar.fillAmount = BarFill();
    }

    /***
    Compute the current HP for the HP bar.
    ***/
    public float BarFill(){
        return HP / maxHealth;
    }

    /***
    Lower the HP by the amount given as parameter.
    @param damage : an int indicating the damage to apply.
    ***/
    public void LowerHP(int damage){
        HP = HP - damage;
    }

    /***
    Increase the HP by the amount given as parameter.
    @param heal : an int indicating the heal to apply.
    ***/
    public void IncreaseHP(int heal){
        HP = HP + heal;
    }

    /***
    Reset the current HP to full.
    ***/
    public void SetHPFull(){
        HP = maxHealth;
    }

}
