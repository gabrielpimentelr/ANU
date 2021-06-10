using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Error : MonoBehaviour
{
    public float speed;
    public int health;
    private Transform player;
    public GameObject deathEffect;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    void Update()
    {
        speed += Time.deltaTime / 10;
        transform.position = 
            Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
    }

    public void TakeDamage()
    {
        health--;
        if(health <= 0)
        {
            Destroy();
        }
    }

    void Destroy()
    {
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

}
