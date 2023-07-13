using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JellyfishShooting : MonoBehaviour
{

    //Reference to game manager
    public GameManager gameManager;

    //FirePoint position
    public Transform firePoint;

    //Object to spawn bullet
    public GameObject bulletPrefab;

    //Direction of the player
    public Vector2 playerDirection;

    //Is Phase 2 of the bossfight currently happening ?
    public bool isPhase2 = false;

    //Fire rate
    float fireRate = 0.5f;
    float canFire = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    /***
    Update is called every frame, if the MonoBehaviour is enabled.
    ***/
    void FixedUpdate(){
        Debug.Log(isPhase2);
        if(gameManager.isPaused() == false){
            playerDirection = GetComponent<JellyfishMovement>().direction;
            if(gameManager.isBossfightHappening == true ) 
            {
                if(gameManager.bossHPbar.GetComponent<JellyfishHealth>().HP <= ((gameManager.bossHPbar.GetComponent<JellyfishHealth>().maxHealth)/2)
                && isPhase2 == false)
                {
                    isPhase2 = true;
                }
                else if(isPhase2 == false)
                {
                    if(Time.time > canFire)
                    {
                        Shoot(playerDirection);
                        Shoot(-RotateBy(playerDirection, 4f));
                        Shoot(-RotateBy(playerDirection, -4f));
                        canFire = Time.time + fireRate;
                    }
                    
                }
                else if(isPhase2 == true) 
                {
                    if(Time.time > canFire)
                    {
                        Shoot(playerDirection);
                        Shoot(RotateBy(playerDirection, 2f));
                        Shoot(-RotateBy(playerDirection, 2f));
                        Shoot(RotateBy(playerDirection, 4f));
                        Shoot(-RotateBy(playerDirection, 4f));
                        Shoot(-RotateBy(playerDirection, 0f));
                        canFire = Time.time + fireRate;
                    }  
                }     
            }  
        }
    }

    /***
    Shooting mechanic.
    Instantiate a bullet at the position of the firePoint.
    ***/
    void Shoot(Vector2 direction) {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        FindObjectOfType<AudioManager>().PlayOneShot("BossAttack");
        Rigidbody2D rigidbodyBullet = bullet.GetComponent<Rigidbody2D>();
        rigidbodyBullet.AddForce(direction * bullet.GetComponent<JellyfishBullet>().speed, ForceMode2D.Impulse);
    }

    /***
    Rotate a Vector2 by a certain angle>
    @param v : vector2 to rotate.
    @param a : float representing the angle of the rotation.
    @return : the input vector rotated by the input rotation angle.
    ***/
    public static Vector2 RotateBy(Vector2 v, float a)
        {
            var ca = System.Math.Cos(a);
            var sa = System.Math.Sin(a);
            var rx = v.x * ca - v.y * sa;

            return new Vector2((float)rx, (float)(v.x * sa + v.y * ca));
        }
}
