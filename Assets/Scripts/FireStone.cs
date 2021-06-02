using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireStone : MonoBehaviour
{
    Collider2D stoneFire;
    public float time = 0;
    public float activateTime;
    bool fire;
    Animator anim;


    // Start is called before the first frame update
    void Start()
    {
        stoneFire = this.GetComponent<Collider2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
          time += Time.deltaTime;
        if(time >= activateTime && !fire)
        {
            fire = true;
            OnFire();
            time = 0;

        }
         if(time >= activateTime && fire)
        {
            fire = false;
            OffFire();
            time = 0;
        }
       
    }
    public void OnFire()
    {
        //stoneFire.enabled = true;
        anim.SetBool("Fire", true );
    }
    public void OffFire()
    {
        //toneFire.enabled = false;
        anim.SetBool("Fire", false );
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player" && !fire)
        {
            
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player" && fire)
        {
            GameController.instance.LoseLife();

        }

    }
}
   

