using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    public int extraJumpsValue;

    private float moveInput;
    private Rigidbody2D rig;
    private SpriteRenderer spr;
    private int extraJumps;

    public bool isGrounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;
    //private bool doubleJump;

  
    


    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        spr = GetComponent<SpriteRenderer>();
        extraJumps = extraJumpsValue;
    }

    void FixedUpdate()
    {
        //movimento do personagem
        moveInput = Input.GetAxis("Horizontal");
        rig.velocity = new Vector2(moveInput * speed, rig.velocity.y);

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
        
        // pula
        if(Input.GetButtonDown("Jump") && extraJumps > 0) 
        {
            rig.velocity = Vector2.up * jumpForce;
            extraJumps--;
        } else if(Input.GetButtonDown("Jump") && extraJumpsValue == 0 && isGrounded)
        {
            rig.velocity = Vector2.up * jumpForce;
        } 
     
        
    }
   
  
}

