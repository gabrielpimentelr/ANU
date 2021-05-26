using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    public Rigidbody2D rb;
    public int damage;
    public GameObject impactEffect;
    //commit

    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * speed;
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        EnemyHealth enemy = other.GetComponent<EnemyHealth>();
        if(enemy != null)
        {
            enemy.TakeDamage();
        }
        Instantiate(impactEffect, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
