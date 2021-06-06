using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prova : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed;
    public float flipTime;

    private float time;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        time += Time.deltaTime;
        Move();
    }

    void Move()
    {
        if(time >= flipTime)
        {
            Flip();
            time = 0;
        }
        rb.velocity = new Vector2(rb.velocity.x, speed);
    }

    void Flip()
    {
        speed *= -1;
    }
}
