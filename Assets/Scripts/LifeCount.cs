using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeCount : MonoBehaviour
{

    public Image[] lives;
    public int livesRemaining;

    public void LoseLife()
    {
        //diminiu o valor das vidas restantes
        livesRemaining--;

        //esconde uma imagem de coração
        lives[livesRemaining].enabled = false;

        //se ficar sem vida, perde o jogo
        if(livesRemaining == 0)
        {
            print("Game Over");
        }

    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Return))
        {
            LoseLife();
        }
    }


}
