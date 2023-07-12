using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JellyfishHealth : MonoBehaviour
{

    //Reference to health bar aspect
    private Image healthBar;

    //Maximum HP
    public float maxHealth = 100;

    //Current HP
    public float HP;

    // Start is called before the first frame update
    void Start()
    {
        HP = maxHealth;
        healthBar = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
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
    Returns the current HP of the object.
    ***/
    public float GetHP(){
        return HP;
    }

}
