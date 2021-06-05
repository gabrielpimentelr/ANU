using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloud : MonoBehaviour
{
    public float speed;
    public Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        rb.velocity = transform.right * -speed;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Destroy")
        {
            Destroy(gameObject);
        }
    }
}
