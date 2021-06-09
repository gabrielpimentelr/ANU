using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tear : MonoBehaviour
{

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "GroundWall") 
        {
            FindObjectOfType<AudioManager>().Play("water_drop");
            Destroy(gameObject);
        }
    }
}
