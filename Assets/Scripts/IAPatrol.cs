using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IAPatrol : MonoBehaviour
{
    
    public float speed;
    public float checkRadius;
    public LayerMask whatIsGround;
    public LayerMask whatIsEnemy;
    public Transform groundCheck;
    public Transform footGroundCheck;
    public Time time;

    public bool isGrounded;
    private Rigidbody2D rb;
    private SpriteRenderer spr;
    public Collider2D bc;
    private bool mustPatrol;
    private bool mustTurn;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spr = GetComponent<SpriteRenderer>();

        mustPatrol = true;
    }

    void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(footGroundCheck.position,checkRadius,whatIsGround);
        if(mustPatrol)
        {
            mustTurn = !Physics2D.OverlapCircle(groundCheck.position,checkRadius,whatIsGround);
        }
        
    }


    void Update()
    {
        if(mustPatrol)
        {
            Patrol();
        }
    }

    void Patrol()
    {
        if(isGrounded && mustTurn || bc.IsTouchingLayers(whatIsGround) || bc.IsTouchingLayers(whatIsEnemy))
        {
        Flip();
        }
        rb.velocity = new Vector2(speed, rb.velocity.y);
    }

    void Flip()
    {
        mustPatrol = false;
        transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
        speed *= -1;
        mustPatrol = true;
    }
}
