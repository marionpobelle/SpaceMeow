using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JellyfishBullet : MonoBehaviour
{

    public float speed = 0.5f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    /***
    Behavior upon leaving screen view.
    Delete Object to save space.
    ***/
    void OnBecameInvisible(){
        Destroy(gameObject);
    }
}
