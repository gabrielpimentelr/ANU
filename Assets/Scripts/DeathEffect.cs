using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathEffect : MonoBehaviour
{

    public float time = 0;

    void Update()
    {
        time += Time.deltaTime;
        if(time >= 0.292f)
        {
            Destroy(gameObject);
        }
    }
}
