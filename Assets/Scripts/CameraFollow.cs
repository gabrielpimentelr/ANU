using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public Transform player;
    public Vector3 offset;
    public float smoothValue;

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
        Vector3 temp = transform.position;
        temp.x = player.position.x;
        transform.position = temp;


        //segue no eixo x e y suavemente
        //Vector3 playerPosition = player.position + offset;
        //Vector3 smoothPosition = Vector3.Lerp(transform.position, playerPosition,smoothValue * Time.fixedDeltaTime);
        //transform.position = smoothPosition;
    }
}
