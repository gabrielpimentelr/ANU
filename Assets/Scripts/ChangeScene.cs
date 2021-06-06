using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public string nomeDaCena;
    private GameMaster gameMaster;
    private Transform startPosition;

    public void ChangeS()
    {
        SceneManager.LoadScene(nomeDaCena);
    }

    public void Sair()
    {
        Application.Quit();
    }

    void OnTriggerEnter2D(Collider2D collision)
        {
            if(collision.gameObject.tag == "Player")
            {
                startPosition = GameObject.FindGameObjectWithTag("Respawn").GetComponent<Transform>();
                gameMaster = GameObject.FindGameObjectWithTag("GameMaster").GetComponent<GameMaster>();
                gameMaster.lastCheckPointPos = startPosition.position;
                SceneManager.LoadScene(nomeDaCena);
                Debug.Log(DeathsAndTime.deathCount);
                Debug.Log(DeathsAndTime.timeCount);
            }
        }
}
