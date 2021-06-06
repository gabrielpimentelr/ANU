using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Corote : MonoBehaviour
{
    public float speed;
    public Rigidbody2D rb;
    public GameObject impactEffect;

    private Transform player;
    private Vector2 target;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        if(transform.position.x < player.position.x)
        {
            rb.velocity = transform.right * speed;
        }
        if(transform.position.x > player.position.x)
        {
            rb.velocity = transform.right * -speed;
        }
    }


    void OnCollisionEnter2D(Collision2D other) 
    {
        Instantiate(impactEffect, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
