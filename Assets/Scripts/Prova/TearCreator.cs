using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TearCreator : MonoBehaviour
{
    public GameObject tear;
    public float createRate;
    public float time;
    private float random;

    void Start()
    {
        random = Random.Range(0, createRate);
    }
    void Update()
    {
        if(HealthBar.instance.phaseThree)
        {
            time += Time.deltaTime;
            if(time >= random)
            {
                CreateTear();
                random = Random.Range(0, createRate);
                time = 0;
            }
        }
    }

    void CreateTear()
    {
        Instantiate(tear, transform.position, Quaternion.Euler(0, 0, 0));
    }
}
