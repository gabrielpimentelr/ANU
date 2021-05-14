using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IAAggro : MonoBehaviour
{
    
    public Transform player;
    public float aggroRange;
    public float speed;
    public SpriteRenderer spr;
    public bool mustChase;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        //distancia do jogador
        float distance = Vector2.Distance(transform.position, player.position);
        
        //se a distancia for menor que o range do agro ativa o método de perseguir
        if(distance < aggroRange)
        {
            mustChase = true;
        }

        if(mustChase)
        {
            Chase();
        }

    }

    void Chase()
    {
        //inimigo do lado esquerdo no player, move pra direita
        if(transform.position.x < player.position.x)
        {
            rb.velocity = new Vector2(speed, rb.velocity.y);
            spr.flipX = false;
        }
        //inimigo do lado direito do player, move pra esquerda
        else if(transform.position.x > player.position.x)
        {
            rb.velocity = new Vector2(-speed, rb.velocity.y);
            spr.flipX = true;
        }

    }
}
