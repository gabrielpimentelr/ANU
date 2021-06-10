using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloud : MonoBehaviour
{
    public float speed;

    //public Rigidbody2D rb;
    //private Transform player;
    //private Transform playerPos;

    void Awake()
    {
        //rb = GetComponent<Rigidbody2D>();
        //player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }
    void Update()
    {
        transform.Translate(-speed * Time.deltaTime, 0, 0);


        //rb.velocity = transform.right * -speed;

        /*
        if(playerPos != null)
        {
            player.position = Vector2.MoveTowards(player.position, playerPos.position, 10 * Time.deltaTime);
            Debug.Log(playerPos.position);
        }*/

    }

    void OnTriggerStay2D(Collider2D other)
    {
        if(other.gameObject.tag == "Destroy")
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D other) 
        {
        if(other.gameObject.tag == "Player")
        {
            //playerPos = other.gameObject.transform;
            //Debug.Log(playerPos);

            other.transform.parent = gameObject.transform;
        }
    }

    private void OnCollisionExit2D(Collision2D other) 
    {
        if(other.gameObject.tag == "Player")
        {
            //playerPos = null;

            other.transform.parent = null;
        }
    }
}
