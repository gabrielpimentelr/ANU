using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Image fillBar;
    public float health;

    public void LoseHealth(int damage)
    {
        health -= damage;
        fillBar.fillAmount = health / 100;
        if(health <= 0)
        {
            Destroy(gameObject);
        }
        Debug.Log(fillBar.fillAmount);
    }
    
}
