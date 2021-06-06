using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    public Rigidbody2D rb;
    public int damage;
    public GameObject impactEffect;
    private bool damaged;
    public float force;

    // Start is called before the first frame update
    void Start()
    {
        //rb.velocity = transform.right * speed;
        if(Player.instance.facingRight)
        {
            rb.velocity = new Vector2(speed, force);
        }else
        {
            rb.velocity = new Vector2(-speed, force);
        }
        
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        EnemyHealth enemy = other.GetComponent<EnemyHealth>();
        if(enemy != null && !damaged)
        {
            damaged = true;
            enemy.TakeDamage();
        }
        HealthBar prova = other.GetComponent<HealthBar>();
        if(prova != null && !damaged)
        {
            damaged = true;
            prova.LoseHealth();
        }
        Question question = other.GetComponent<Question>();
        if(question != null && !damaged)
        {
            damaged = true;
            question.TakeDamage();
        }

        Instantiate(impactEffect, transform.position, transform.rotation);
        Destroy(gameObject);
    }

}
