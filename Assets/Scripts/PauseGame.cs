using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseGame : MonoBehaviour
{
    public bool gamePaused = false;
    public GameObject pauseMenu;
    public static PauseGame instance;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if(!gamePaused)
        {
            Cursor.visible = false;
        }else
        {
            Cursor.visible = true;
        }

        if (Input.GetButtonDown("Cancel"))
        {
            if (!gamePaused)
            {
                Pause();
            }
            else 
            {
                UnpauseGame();
            }
        }
    }

    public void UnpauseGame()
    {
        pauseMenu.SetActive(false);
        Cursor.visible = false;
        gamePaused = false;
        Time.timeScale = 1;
        DeathsAndTime.running = true;
    }

    public void Pause()
    {
        Time.timeScale = 0;
        gamePaused = true;
        Cursor.visible = true;
        pauseMenu.SetActive(true);
        DeathsAndTime.running = false;
    }
}


