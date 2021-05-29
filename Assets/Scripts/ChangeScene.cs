using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public string nomeDaCena;
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
            SceneManager.LoadScene(nomeDaCena);
        }
        


    }
}
