using System.Net.Mime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JellyfishMovement : MonoBehaviour
{

    //Jellyfish movement speed
    public float speed;

    //Reference to Game manager
    public GameManager gameManager;

    //Reference to player
    public GameObject player;

    //Is this the jellyfish's first movement ?
    public bool isFirstMovement = true;
    
    //Jellyfish rigidbody2D
    public Rigidbody2D rigidbodyJellyfish;

    //Offset from the screenbounds that limits where the jellyfish can go
    public float offset;

    //Distance between the jellyfish and its current destination
    private float distance;

    //Animator for the jellyfish
    public Animator anim;

    //Direction towards the player
    public Vector2 direction;

    //Angle between the current direction and the player
    public float angle;

    //Current destination of the jellyfish
    private Vector2 currentDestination;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        gameManager = FindObjectOfType<GameManager>();
        //Select random coords in game screen minus offset
        currentDestination = new Vector2(((gameManager.min_x + gameManager.max_x)/2),((gameManager.min_y + gameManager.max_y)/2));
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Holds the current position
        Vector3 jellyfishPos = transform.position;
        distance = Vector2.Distance(transform.position, currentDestination);

        //Define a new destination for the jellyfish once the previous one has been attained
        if(distance == 0 && isFirstMovement == true)
        {   
            isFirstMovement = false;
            gameManager.bossHPbar.SetActive(true);
            gameManager.SetBossfightStart();
            currentDestination = new Vector2(Random.Range(gameManager.min_x + offset,gameManager.max_x - offset),Random.Range(gameManager.min_y + offset,gameManager.max_y - offset));
        }
        else if(distance == 0)
        {
            currentDestination = new Vector2(Random.Range(gameManager.min_x + offset,gameManager.max_x - offset),Random.Range(gameManager.min_y + offset,gameManager.max_y - offset));
        }
        //Determine where the player is for the shooting angle
        direction = (Vector2)player.transform.position - (Vector2)transform.position;
        direction.Normalize();
        angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        //Moves the jellyfish towards its current destination
        MoveJellyfish();
      
    }

    /***
    Move the jellyfish towards its current destination.
    ***/
    public void MoveJellyfish(){
        if(gameManager.isBossDead == false){
            transform.position = transform.position = Vector2.MoveTowards(this.transform.position, currentDestination, speed * Time.deltaTime);
        }
    }

    /***
    Sequence to execute when the jellyfish dies.
    ***/
    public void BossDeathSequence(){
        anim.SetTrigger("bossDied");
    }
}
