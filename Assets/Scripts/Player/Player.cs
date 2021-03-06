using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    public int extraJumpsValue;
    public float enemyForce;
    public float espinhoForce;
    public float wallForce;
    
    public static Player instance;
    public bool facingRight = true;
    private float moveInput;
    private Rigidbody2D rb;
    private int extraJumps;
    public Animator anim;
    private float time;

    public bool isGrounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;
    public bool playerDie;

    bool isBlowing;

    private float timeStep;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        playerDie = false;
        extraJumps = extraJumpsValue;
        instance = this;
    }

    void FixedUpdate()
    {
        //movimento do personagem
        moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);

        //vira o personagem pra direita ou pra esquerda

        if (moveInput < 0 && facingRight)
        {
            Flip();
        }
        if (moveInput > 0 && !facingRight)
        {
            Flip();
        }

        // cria um círculo no pé do personagem e armazena na variável isGrounded
        isGrounded = Physics2D.OverlapCircle(groundCheck.position,checkRadius,whatIsGround);


        if(isGrounded && moveInput != 0 && timeStep >= 0.15f)
        {
            FindObjectOfType<AudioManager>().Play("step");
            timeStep = 0;
        }

    }

    void Update()
    {   
        timeStep += Time.deltaTime;
        time += Time.deltaTime;
        // verifica se o personagem está no chão
        if(isGrounded)
        {
            extraJumps = extraJumpsValue;
        }

        // pula
        if(Input.GetButtonDown("Jump") && extraJumps > 0 && !isBlowing) 
        {
            rb.velocity = Vector2.up * jumpForce;
            extraJumps--;
            FindObjectOfType<AudioManager>().Play("jump");
        } else if(Input.GetButtonDown("Jump") && extraJumpsValue == 0 && isGrounded)
        {
            rb.velocity = Vector2.up * jumpForce;
            FindObjectOfType<AudioManager>().Play("jump");
        } 

        //die
        if(playerDie && time >= 0.292f)
        {
            GameController.instance.Restart();
        }

    }
   
   void OnCollisionEnter2D(Collision2D other) 
    {
         if(other.gameObject.layer == 9)
         {
             GameController.instance.LoseLife();
             rb.AddForce(new Vector2(0f, enemyForce), ForceMode2D.Impulse);
         }
         if(other.gameObject.layer == 7)
         {
             GameController.instance.LoseLife();
             rb.AddForce(new Vector2(0f, enemyForce), ForceMode2D.Impulse);
             isGrounded = true;
         }

         if(other.gameObject.tag == "Espinho")
         {
             GameController.instance.LoseLife();
             rb.AddForce(new Vector2(0f, espinhoForce), ForceMode2D.Impulse);
             isGrounded = true;
         }
          if(other.gameObject.tag == "Saw")
         {
             GameController.instance.LoseLife();
         }
         if(other.gameObject.tag == "corote")
         {
             GameController.instance.LoseLife();
             rb.AddForce(new Vector2(0f, enemyForce), ForceMode2D.Impulse);
             isGrounded = true;
         }
         if(other.gameObject.tag == "GroundWall")
         {
             GameController.instance.LoseLife();
             rb.AddForce(new Vector2(0f, wallForce), ForceMode2D.Impulse);
         }
         if(other.gameObject.layer == 12)
         {
             Die();
             
         }
    }
     void OnTriggerStay2D(Collider2D collider)
    {
        if(collider.gameObject.layer == 13)
        {
            isBlowing = true;
        }
    }
    void OnTriggerExit2D(Collider2D collider)
    {
        if(collider.gameObject.layer == 13)
        {
            isBlowing = false;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.layer == 9)
        {
            GameController.instance.LoseLife();
        }
         if(other.gameObject.tag == "SpikedBall")
         {
             GameController.instance.LoseLife();
         }
    }


    void Flip()
    {
        transform.Rotate(0f, 180f, 0f);
        facingRight = !facingRight;
    }

    public void Die()
    {
        time = 0;
        playerDie = true;
        anim.SetTrigger("die");
    }
  
    
}

