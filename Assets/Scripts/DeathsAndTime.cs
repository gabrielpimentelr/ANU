using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathsAndTime : MonoBehaviour
{
    public static int deathCount;
    public static float timeCount;
    public static bool running;
    public static string niceTime;

    void Start()
    {
        running = true;
    }
    void Update()
    {
        if(running)
        {
             timeCount += Time.deltaTime;
        }

        int minutes = Mathf.FloorToInt(timeCount / 60F);
        int seconds = Mathf.FloorToInt(timeCount - minutes * 60);
        niceTime = string.Format("{0:0}:{1:00}", minutes, seconds);
    }
}
