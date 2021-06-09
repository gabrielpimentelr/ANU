using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Image fillBar;
    public float health;
    private float damage;

    private Animator anim;

    void Start()
    {
        damage = 100 / health;
        anim = GetComponent<Animator>();
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
    }
    
}
