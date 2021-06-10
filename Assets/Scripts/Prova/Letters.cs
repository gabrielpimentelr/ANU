using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Letters : MonoBehaviour
{
    public float speed;
    public Transform moveDirection;
    //private Rigidbody2D rb;
    public GameObject deathEffect;


    
    /*void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    */

    void Update()
    {
        transform.position = 
            Vector2.MoveTowards(transform.position, moveDirection.position, speed * Time.deltaTime);
    }

    void Destroy()
    {
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.layer == 6 || other.gameObject.tag == "GroundWall") 
        {
            Destroy();
        }
    }
}
