using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Question : MonoBehaviour
{
    public static Question instance;
    public float speed;
    public Transform [] moveDirections;
    private int randomDirection;

    public int health;
    public Transform [] createDirections;
    public GameObject [] letters;
    private float time;
    public int destroyTime;
    public GameObject deathEffect;
    

    void Start()
    {
        instance = this;
        randomDirection = Random.Range(0, moveDirections.Length);
    }
    void Update()
    {
        time += Time.deltaTime;
        Move();
        if(time >= Random.Range(destroyTime / 2, destroyTime + 1))
        {
            Destroy();
        }
    }

    void Move()
    {
        transform.position = 
            Vector2.MoveTowards(transform.position, moveDirections[randomDirection].position, speed * Time.deltaTime);
    }
    
    void Destroy()
    {
        for (int i = 0; i < createDirections.Length; i++)
        {
            Instantiate(letters[i], createDirections[i].position, createDirections[i].rotation); 
        }
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    public void TakeDamage()
    {
        health--;
        if(health <= 0)
        {
            Destroy();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.layer == 6 || other.gameObject.tag == "GroundWall") 
        {
            speed *= -1;
        }
    }
}
