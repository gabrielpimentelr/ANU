using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathsAndTime : MonoBehaviour
{
    public static int deathCount;
    public static float timeCount;

    void Update()
    {
        timeCount += Time.deltaTime;
    }
}
