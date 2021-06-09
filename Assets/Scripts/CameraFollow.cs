using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public Transform player;
    public float smoothValue = 7;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        
    }
    void LateUpdate()
    {
        Follow();
    }

    void Follow()
    {
        //segue apenas no eixo x
        /*
        Vector3 temp = transform.position;
        temp.x = player.position.x;
        transform.position = temp;
        */


        Vector3 newPosition = new Vector3(player.position.x, transform.position.y, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, newPosition, smoothValue * Time.deltaTime);
    }
}
