using UnityEngine;

public class shooting : MonoBehaviour
{
    //Reference to game manager
    public GameManager gameManager;

    //Reference to PlayerBehavior
    public PlayerBehavior playerBehavior;

    //FirePoint position
    public Transform firePoint;

    //Object to spawn bullet
    public GameObject bulletPrefab;

    //Bullet speed
    public float speed;

    //Fire rate hold
    float fireRateHold = 0.3f;
    float canFireHold = 0.3f;

    //Fire rate click
    float fireRate = 0.15f;
    float canFire = 0.15f;

    /***
    Update is called every frame, if the MonoBehaviour is enabled.
    ***/
    void Update(){
        if(gameManager.isPaused() == false){
            if(playerBehavior.GetDeath() == false){
                //"fire1" is a keyword for standard shooting button, here its left mouse button
                if(Input.GetButtonDown("Fire1") && Time.time > canFire && !Input.GetButton("Fire2")) {
                    Shoot();
                    canFire = Time.time + fireRate;
                }
                //"fire2" keyword for right mouse button
                else if(Input.GetButton("Fire2")  && Time.time > canFireHold && !Input.GetButtonDown("Fire1") && Time.time > canFire) {
                    Shoot();
                    canFireHold = Time.time + fireRateHold;
                }
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
        FindObjectOfType<AudioManager>().PlayOneShot("Shot");
        Rigidbody2D rigidbodyBullet = bullet.GetComponent<Rigidbody2D>();
        rigidbodyBullet.AddForce(firePoint.up * speed, ForceMode2D.Impulse);
    }
}

