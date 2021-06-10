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
    public GameObject error;
    public Transform createPoint;
    public float createQuestionRate;
    public float createErrorRate;
    private float createQuestionTime;
    private float createErrorTime;

    private Animator anim;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        createErrorTime = createErrorRate;
    }
    void Update()
    {
        time += Time.deltaTime;
        createQuestionTime += Time.deltaTime;
        Move();

        if(createQuestionTime >= createQuestionRate)
        {
            Instantiate(question, createPoint.position, Quaternion.identity);
            createQuestionTime = 0;
        }

        if(HealthBar.instance.phaseTwo)
        {
            createErrorTime += Time.deltaTime;
            if(createErrorTime >= createErrorRate)
            {
                Instantiate(error, createPoint.position, Quaternion.identity);
                createErrorTime = 0;
                createErrorRate *= 0.9f;
            }
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
