using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public static GameController instance;
    public Image[] lives;
    public int livesRemaining;
    public bool playerDie;

    void Start()
    {
        instance = this;
    }

    public void LoseLife()
    {
        //diminiu o valor das vidas restantes
        livesRemaining--;

        //esconde uma imagem de coração
        lives[livesRemaining].enabled = false;

        //se ficar sem vida, da restart na fase
        if(livesRemaining <= 0)
        {
            Player.instance.Die();
        }

    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
