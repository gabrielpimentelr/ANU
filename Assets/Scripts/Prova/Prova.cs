using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prova : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed;
    public float flipTime; 

    private float time;

    public GameObject question;
    public Transform createPoint;
    public float createRate;
    private float createTime;

    private Animator anim;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        time += Time.deltaTime;
        createTime += Time.deltaTime;
        Move();

        if(createTime >= createRate)
        {
            Instantiate(question, createPoint.position, Quaternion.identity);
            createTime = 0;
        }
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
