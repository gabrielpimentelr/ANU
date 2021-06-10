using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TearsController : MonoBehaviour
{

    public float speed;
    public Transform player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    void Update()
    {
        Move();
        /*
        if(HealthBar.instance.phaseThree)
        {
            Move();
        }
        */
        
    }

    void Move()
    {
        Vector2 newPosition = new Vector2(player.position.x, transform.position.y);
        transform.position = Vector2.MoveTowards(transform.position, newPosition, speed * Time.deltaTime);
        //transform.position = Vector3.Lerp(transform.position, newPosition, speed * Time.deltaTime);
    }
}
