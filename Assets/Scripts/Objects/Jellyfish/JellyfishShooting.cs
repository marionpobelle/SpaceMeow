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

    public Vector2 playerDirection = new Vector2(1, 0);

    //Fire rate click
    float fireRate = 0.5f;
    float canFire = 0.5f;

    /***
    Update is called every frame, if the MonoBehaviour is enabled.
    ***/
    void FixedUpdate(){
        if(gameManager.isPaused() == false){
            playerDirection = GetComponent<JellyfishMovement>().direction;
            if(Time.time > canFire)
            {
                Shoot();
                canFire = Time.time + fireRate;
            }   
        }
    }

    /***
    Shooting mechanic.
    Instantiate a bullet at the position and angle of the firePoint.
    ***/
    void Shoot() {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        //Play bullet sound
        FindObjectOfType<AudioManager>().PlayOneShot("BossAttack");
        Rigidbody2D rigidbodyBullet = bullet.GetComponent<Rigidbody2D>();
        rigidbodyBullet.AddForce(playerDirection * bullet.GetComponent<JellyfishBullet>().speed, ForceMode2D.Impulse);
    }
}
