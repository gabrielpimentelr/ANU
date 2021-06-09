using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudCreator : MonoBehaviour
{
    public Transform createPoint;
    public GameObject cloud;
    public float createRate;
    public float time;


    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if(time >= createRate)
        {
            CreateCloud();
            time = 0;
        }
        
    }

    void CreateCloud()
    {
        Instantiate(cloud, createPoint.position, Quaternion.identity);
    }
}
