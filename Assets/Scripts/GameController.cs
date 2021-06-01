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
    public bool invulnerable;
    public float time;
    

    void Start()
    {
        instance = this;
    }
    
    void Update()
    {
        time += Time.deltaTime;
        if(time >= 1)
        {
            invulnerable = false;
        }
    }

    public void LoseLife()
    {
        if (!invulnerable)
        {
            invulnerable = true;
            time = 0;
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
        

    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
