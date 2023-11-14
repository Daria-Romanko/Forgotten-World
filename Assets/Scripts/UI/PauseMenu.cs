using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    bool gameIsPaused = false;

    public GameObject pauseMenuUI;
    
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            if (!gameIsPaused)
            {
                Pause();

            }
            else
            {
                Resume();
            }
        }
    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        gameIsPaused = true;
        
        Time.timeScale = 0f;
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        gameIsPaused = false;

        Time.timeScale = 1f;
    }

    public void Quit()
    {
        SceneManager.LoadScene("Menu");
    }

}
