using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Livros : MonoBehaviour
{
    private GameMaster gameMaster;

    void Start()
    {
        gameMaster = GameObject.FindGameObjectWithTag("GameMaster").GetComponent<GameMaster>();
    }
      void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.tag == "Player")
        {
            gameMaster.lastCheckPointPos = transform.position;
            Destroy(gameObject);
        }
    }
}

