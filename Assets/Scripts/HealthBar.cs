using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Image fillBar;
    public float health;
    private float damage;

    void Start()
    {
        damage = 100 / health;
    }
    public void LoseHealth()
    {
        health --;
        fillBar.fillAmount -= damage / 100;
        if(health <= 0)
        {
            Destroy(gameObject);
        }
        Debug.Log(fillBar.fillAmount);
    }
    
}
