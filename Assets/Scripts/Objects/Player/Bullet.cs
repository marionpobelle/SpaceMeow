using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    //Animation upon collision
    public Animator anim;
    public GameObject hitEffect;
    
    //Reference to game manager
    public GameManager gameManager;

    //Floating points
    public GameObject floatingPoints;

    /***
    Awake is called when the script instance is being loaded.
    ***/
    void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
        floatingPoints = gameManager.floatingPoints;
    }

    /***
    Behavior upon collision.
    -Meteors
    -Boss
    @param other : a collider.
    ***/
    void OnTriggerEnter2D(Collider2D other) {
        //If Object collides with a meteor
        if(other.gameObject.tag == "Enemy"){
            int meteorHP;
            int meteorDestScore;
            if(other.name == "BigMeteor"){
                other.GetComponent<BigMeteorBehavior>().lowerHP();
                meteorHP = other.GetComponent<BigMeteorBehavior>().GetHP();
                meteorDestScore = other.GetComponent<BigMeteorBehavior>().GetDestScore();
                if (meteorHP <= 0){
                    GameObject points = Instantiate(floatingPoints, other.transform.position + new Vector3(0, 1, 0), Quaternion.identity);
                    points.transform.GetChild(0).GetComponent<TextMesh>().text = ("+"+meteorDestScore.ToString());
                    gameManager.IncreaseScore(meteorDestScore);
                    other.GetComponent<BigMeteorBehavior>().animDest();
                }else{
                    GameObject points = Instantiate(floatingPoints, other.transform.position + new Vector3(0, 1, 0), Quaternion.identity);
                    points.transform.GetChild(0).GetComponent<TextMesh>().text = "+1";
                    gameManager.IncreaseScore(1);
                    FindObjectOfType<AudioManager>().Play("MeteorHit");
                    anim.SetTrigger("hit");
                }
                    
            }
            else if(other.name == "TinyMeteor"){
                other.GetComponent<SmallMeteorBehavior>().lowerHP();
                meteorHP = other.GetComponent<SmallMeteorBehavior>().GetHP();
                meteorDestScore = other.GetComponent<SmallMeteorBehavior>().GetDestScore();
                if(meteorHP <= 0){
                    GameObject points = Instantiate(floatingPoints, other.transform.position + new Vector3(0, 0.5f, 0), Quaternion.identity);
                    points.transform.GetChild(0).GetComponent<TextMesh>().text = ("+"+meteorDestScore.ToString());
                    gameManager.IncreaseScore(meteorDestScore);
                        other.GetComponent<SmallMeteorBehavior>().animDest();
                    }else{
                    GameObject points = Instantiate(floatingPoints, other.transform.position + new Vector3(0, 0.5f, 0), Quaternion.identity);
                    points.transform.GetChild(0).GetComponent<TextMesh>().text = "+1";
                    gameManager.IncreaseScore(1);
                    FindObjectOfType<AudioManager>().Play("MeteorHit");
                        anim.SetTrigger("hit");
                    }
            }
        }
        if(other.gameObject.tag == "Boss"){
            if(gameManager.isBossfightHappening == true){
                gameManager.bossHPbar.GetComponent<JellyfishHealth>().LowerHP(1);
                float bossHP = gameManager.bossHPbar.GetComponent<JellyfishHealth>().GetHP();
                if(bossHP <= 0){
                    gameManager.SetBossDead();
                    gameManager.StopBossfight();
                    other.GetComponent<JellyfishMovement>().BossDeathSequence();
                    Debug.Log("Boss is dead");
                        
                }else{
                    GameObject points = Instantiate(floatingPoints, other.transform.position + new Vector3(0, 2, 0), Quaternion.identity);
                    points.transform.GetChild(0).GetComponent<TextMesh>().text = "+1";
                    gameManager.IncreaseScore(1);
                    FindObjectOfType<AudioManager>().Play("BossHit");
                    anim.SetTrigger("hit");
                }
            }
        }
    }

    /***
    Behavior upon leaving screen view.
    Delete Object to save space.
    ***/
    void OnBecameInvisible(){
        Destroy(gameObject);
    }

}
