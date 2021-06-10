using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public static HealthBar instance;

    public Image fillBar;
    public float totalHealth;
    private float health;
    private float damage;

    public bool phaseTwo;
    public bool phaseThree;

    private Animator anim;

    void Start()
    {
        instance = this;

        anim = GetComponent<Animator>();
        damage = 100 / totalHealth;
        health = totalHealth;
    }
    public void LoseHealth()
    {
        anim.SetTrigger("hit");
        health --;
        fillBar.fillAmount -= damage / 100;
        if(health <= 0)
        {
            Destroy(gameObject);
        }

        if(health <= totalHealth * 0.7)
        {
            phaseTwo = true;
        }

        if(health <= totalHealth * 0.4)
        {
            phaseThree = true;
        }
    }
    
}
