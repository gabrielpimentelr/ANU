using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireStone : MonoBehaviour
{
     Collider2D stoneFire;
     



    // Start is called before the first frame update
    void Start()
    {
        stoneFire = this.GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void OnFire()
    {
        stoneFire.enabled = true;
    }
    public void offFire()
    {
        stoneFire.enabled = false;
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player" && stoneFire.enabled == false)
        {
            
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player" && stoneFire.enabled == true)
        {
            GameController.instance.Restart();

        }

    }
}
   

