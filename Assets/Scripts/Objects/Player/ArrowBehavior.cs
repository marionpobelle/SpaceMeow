using UnityEngine;

public class ArrowBehavior : MonoBehaviour
{
    //Player transform
    public Transform playerPos;

    //Arrow rigidbody2D
    public Rigidbody2D rb;

    //Main camera
    public Camera cam;

    //Cursor position
    Vector2 mousePos;

    //Animation for taking damage
    public Animator anim;

    /***
    FixedUpdate has the frequency of the physics system; it is called every fixed frame-rate frame.
    ***/
    void FixedUpdate(){   
        //Get cursor position and convert point relative to game camera
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        //Match the arrow position to the player
        transform.position = playerPos.position;
        //Make the firepoint follow the cursor
        Vector2 lookDir = mousePos - new Vector2(playerPos.position[0], playerPos.position[1]);
        //Compute the angle
        float angle = Mathf.Atan2(lookDir.y,lookDir.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;
    }

    /***
    Plays the damage taken animation.
    ***/
    public void Pulse(){
        anim.SetTrigger(name: "damage");
    }
}
