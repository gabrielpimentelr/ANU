using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IAShooter : MonoBehaviour
{

    public static IAShooter instance;
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

    public Transform player;
    public float aggroRange;
    public bool mustChase;
    private bool facingRight;

    public float shootRange;
    public bool mustShoot;
    private bool shooting;
    private EnemyWeapon weapon;

    private SpriteRenderer chatSpriteRenderer;
    private bool chatActive;
    public GameObject chatBubble;

    void Start()
    {
        instance = this;
        rb = GetComponent<Rigidbody2D>();
        weapon = GetComponent<EnemyWeapon>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        chatSpriteRenderer = chatBubble.GetComponent<SpriteRenderer>();

        isChilling = true;
        facingRight = true;
        mustShoot = false;
    }

    void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(footGroundCheck.position,checkRadius,whatIsGround);
        mustTurn = !Physics2D.OverlapCircle(groundCheck.position,checkRadius,whatIsGround);  
    }

    void Update()
    {
        time += Time.deltaTime;

        //distancia do jogador
        float distance = Vector2.Distance(transform.position, player.position);
        
        //se a distancia for menor que o range do agro ativa o método de perseguir
        
        if(distance < shootRange)
        {
            isChilling = false;
            mustChase = false;
            mustShoot = true;
        }
        else if(distance < aggroRange && distance > shootRange)
        {
            isChilling = false;
            mustChase = true;
            mustShoot = true;
            
        }else if (distance > aggroRange * 2)
        {
            isChilling = true;
            mustChase = false;
            mustShoot = false;
            weapon.enabled = false;
        }

        if(isChilling)
        {
            Chill();
        }

        if(mustChase)
        {
            Chase();
        }

        if(mustShoot)
        {
            Shoot();
        }
    }

    void Shoot()
    {
        ActivateChat();
        weapon.enabled = true;
        if(transform.position.x < player.position.x && !facingRight)
        {
            Flip();
        }
        //inimigo do lado direito do player, move pra esquerda
        else if(transform.position.x > player.position.x && facingRight)
        {   
            Flip();
        }
    }


    void Chase()
    {

        //inimigo do lado esquerdo no player, move pra direita
        if(transform.position.x < player.position.x && !facingRight)
        {
            Flip();
        }
        //inimigo do lado direito do player, move pra esquerda
        else if(transform.position.x > player.position.x && facingRight)
        {   
            Flip();
        }

        rb.velocity = new Vector2(speed, rb.velocity.y);
    }

    void Chill()
    {
        DeactivateChat();
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
        facingRight = !facingRight;
        bool wasChilling = false;
        if(isChilling)
        {
            isChilling = false;
            wasChilling = true;
        }
         
        transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
        speed *= -1;
        

        if(chatActive)
        {
            if(facingRight)
            {
                chatBubble.transform.localScale = new Vector2(0.25f, chatBubble.transform.localScale.y);
            }
            else
            {
                chatBubble.transform.localScale = new Vector2(-0.25f, chatBubble.transform.localScale.y);
            }
        }
        
        if(wasChilling)
        {
            isChilling = true;
        }
        wasChilling = false;
    }

    void ActivateChat()
    {
        chatBubble.SetActive(true);
        if(facingRight)
            {
                chatBubble.transform.localScale = new Vector2(0.25f, chatBubble.transform.localScale.y);
            }
            else
            {
                chatBubble.transform.localScale = new Vector2(-0.25f, chatBubble.transform.localScale.y);
            }
        chatActive = true;
    }

    void DeactivateChat()
    {
        chatBubble.SetActive(false);
        chatActive = false;
    }
}
