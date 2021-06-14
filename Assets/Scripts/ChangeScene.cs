using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ChangeScene : MonoBehaviour
{
    public static ChangeScene instance;

    public string nomeDaCena;
    private GameMaster gameMaster;
    private Vector2 startPosition;
    private GameObject audioManager;


    public bool scoreView = false;
    public GameObject score;
    public TextMeshProUGUI scoreLvl;
    public TextMeshProUGUI scoreDeaths;
    public TextMeshProUGUI scoreTime;

    void Start()
    {
        audioManager = GameObject.FindGameObjectWithTag("AudioManager");
        instance = this;
    }

    public void ChangeS()
    {
        Destroy(audioManager);
        SceneManager.LoadScene(nomeDaCena);
        startPosition = GameObject.FindGameObjectWithTag("Respawn").GetComponent<Transform>().position;
        gameMaster = GameObject.FindGameObjectWithTag("GameMaster").GetComponent<GameMaster>();
        gameMaster.lastCheckPointPos = startPosition;
        DeathsAndTime.running = true;
        Time.timeScale = 1;
        DeathsAndTime.timeCount = 0;
        DeathsAndTime.deathCount = 0;
    }

    public void Sair()
    {
        Application.Quit();
    }

    public void ScoreView()
    {
        scoreLvl.text = SceneManager.GetActiveScene().name;
        scoreDeaths.text = DeathsAndTime.deathCount.ToString();
        scoreTime.text = DeathsAndTime.niceTime;
        
        Time.timeScale = 0;
        scoreView = true;
        score.SetActive(true);
        DeathsAndTime.running = false;
    }

    void OnTriggerEnter2D(Collider2D collision)
        {
            if(collision.gameObject.tag == "Player")
            {
                ScoreView();
            }
        }
}
