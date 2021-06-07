using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathEffect : MonoBehaviour
{

    private float time = 0;
    private bool sound;

    void Update()
    {
        time += Time.deltaTime;
        if(time >= 0.292f)
        {
            Destroy(gameObject);
        }

        if(!sound)
        {
            FindObjectOfType<AudioManager>().Play("death_effect");
            sound = true;
        }
    }
}
