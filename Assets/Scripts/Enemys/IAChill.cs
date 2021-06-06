using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IAChill : MonoBehaviour
{
    public static IAChill instance;
    private Rigidbody2D rb;
    public Collider2D bc;
    public float speed;

    public float checkRadius;
    public LayerMask whatIsGround;
    public LayerMask whatIsEnemy;
    public Transform groundCheck;
    public Transform footGroundCheck;
    public bool isGrounded;
    private bool mustTurn;
    private bool isChilling;

    public float time = 0;
    public float movingTime;
    private int direction;
    private bool fliped;
    

    void Start()
    {
        instance = this;
        rb = GetComponent<Rigidbody2D>();

        isChilling = true;
    }

    void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(footGroundCheck.position,checkRadius,whatIsGround);
        mustTurn = !Physics2D.OverlapCircle(groundCheck.position,checkRadius,whatIsGround);  
    }


    void Update()
    {
        time += Time.deltaTime;

        if(isChilling)
        {
            Chill();
        }
    }

    void Chill()
    {
        if(isGrounded && mustTurn)
        {
            Flip();
            
        }else if(bc.IsTouchingLayers(whatIsGround) || bc.IsTouchingLayers(whatIsEnemy))
        {
            Flip();
        }


        if(time >= movingTime)
        {
            direction = Random.Range(0,3);
            time = 0;
            fliped = false;
        }
        if(direction == 0)
        {
            return;
        }
        if(direction == 1)
        {
            rb.velocity = new Vector2(speed, rb.velocity.y);
        }
        if(direction == 2 && !fliped)
        {
            Flip();
            fliped = true;
            rb.velocity = new Vector2(speed, rb.velocity.y);
        }
    }

    void Flip()
    {
        isChilling = false; 
        transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
        speed *= -1;
        isChilling = true;
    }
}
