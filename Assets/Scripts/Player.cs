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
    
    public static Player instance;
    private bool facingRight = true;
    private float moveInput;
    private Rigidbody2D rb;
    private int extraJumps;
    private float time;
    public Animator anim;

    public bool isGrounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;
    public bool playerDie;
    


  
    


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

        //die
        if(playerDie && time >= 0.292f)
        {
            GameController.instance.Restart();
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

         if(other.gameObject.tag == "Espinho")
         {
             Die();
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

