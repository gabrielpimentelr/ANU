using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saw : MonoBehaviour
{
    public float speed;
    public float moveTime;

    private bool dirUp;
    private float timer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       if(dirUp)
       {
           transform.Translate(Vector2.up * speed * Time.deltaTime);
       } 
       else
       {
           transform.Translate(Vector2.down * speed * Time.deltaTime);
       }

       timer += Time.deltaTime;

       if(timer >= moveTime)
       {
           dirUp = !dirUp;
           timer = 0f;
       }
    }
}
