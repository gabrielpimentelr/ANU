using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    public int extraJumpsValue;
    public float enemyForce;
    public bool invulnerable;

    private float moveInput;
    private Rigidbody2D rb;
    private SpriteRenderer spr;
    private int extraJumps;
    private float time;

    public bool isGrounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;
    //private bool doubleJump;

  
    


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spr = GetComponent<SpriteRenderer>();
        extraJumps = extraJumpsValue;
    }

    void FixedUpdate()
    {
        //movimento do personagem
        moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);

        //vira o personagem pra direita ou pra esquerda
        if(moveInput < 0)
        {
            spr.flipX = true;
        }
        else if(moveInput > 0)
        {
            spr.flipX = false;
        }

        // cria um círculo no pé do personagem e armazena na variável isGrounded
        isGrounded = Physics2D.OverlapCircle(groundCheck.position,checkRadius,whatIsGround);

       
    }
    // Update is called once per frame
    void Update()
    {   
        // verifica se o personagem está no chão
        if(isGrounded)
        {
            extraJumps = extraJumpsValue;
        }
        time += Time.deltaTime;
        if(time >= 1)
        {
            invulnerable = false;
        }

        // pula
        if(Input.GetButtonDown("Jump") && extraJumps > 0) 
        {
            rb.velocity = Vector2.up * jumpForce;
            extraJumps--;
        } else if(Input.GetButtonDown("Jump") && extraJumpsValue == 0 && isGrounded)
        {
            rb.velocity = Vector2.up * jumpForce;
        }  
    }
   
   void OnCollisionEnter2D(Collision2D other) 
    {
         if(other.gameObject.layer == 9 && !invulnerable)
         {
             time = 0;
             invulnerable = true;
             GameController.instance.LoseLife();
             rb.AddForce(new Vector2(0f, enemyForce), ForceMode2D.Impulse);
         }
    }
  
}

