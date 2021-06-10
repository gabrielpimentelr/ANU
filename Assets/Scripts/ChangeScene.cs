using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public string nomeDaCena;
    private GameMaster gameMaster;
    private Vector2 startPosition;
    private GameObject audioManager;

    void Start()
    {
        audioManager = GameObject.FindGameObjectWithTag("AudioManager");
    }

    public void ChangeS()
    {
        Destroy(audioManager);
        SceneManager.LoadScene(nomeDaCena);
        startPosition = GameObject.FindGameObjectWithTag("Respawn").GetComponent<Transform>().position;
        gameMaster = GameObject.FindGameObjectWithTag("GameMaster").GetComponent<GameMaster>();
        gameMaster.lastCheckPointPos = startPosition;
        Debug.Log("Mortes - Nível: " + SceneManager.GetActiveScene().name + " --- " + DeathsAndTime.deathCount);
        Debug.Log("Tempo - Nível: " + SceneManager.GetActiveScene().name + " --- " + DeathsAndTime.timeCount);
        DeathsAndTime.timeCount = 0;
        DeathsAndTime.deathCount = 0;
    }

    public void Sair()
    {
        Application.Quit();
    }

    void OnTriggerEnter2D(Collider2D collision)
        {
            if(collision.gameObject.tag == "Player")
            {
                ChangeS();
            }
        }
}
