using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeapon : MonoBehaviour
{
    public Transform firePoint;
    public GameObject enemyBullet;
    public float fireRate;
    private float time;


    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if(time >= fireRate)
        {
            Shoot();
            time = 0;
        }
        
    }

    void Shoot()
    {
        Instantiate(enemyBullet, firePoint.position, Quaternion.identity);
    }
}
