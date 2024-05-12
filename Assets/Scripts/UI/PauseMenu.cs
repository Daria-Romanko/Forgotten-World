using PixelCrushers.DialogueSystem;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    bool gameIsPaused = false;

    public GameObject pauseMenuUI;
    public GameObject[] gameObjects;

    private bool[] puzzleStates;
    PlayerTeleporter playerTeleporter;

    public GameObject finalPanel;

    void Start()
    {
        playerTeleporter = GameObject.FindGameObjectWithTag("Player").gameObject.GetComponent<PlayerTeleporter>();
        puzzleStates = new bool[gameObjects.Length];
        SavePuzzleStates();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
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
        DialogueManager.Pause();
        pauseMenuUI.SetActive(true);
        gameIsPaused = true;

        Time.timeScale = 0f;

        SavePuzzleStates();
        HidePuzzles(); 
        if(playerTeleporter.isTeleporting)
        {
            playerTeleporter.PauseSFX();
        }
    }

    public void ShowFinalPanel()
    {
        DialogueManager.Pause();
        gameIsPaused = true;

        finalPanel.SetActive(true);

        Time.timeScale = 0f;
        SavePuzzleStates();
        HidePuzzles();
        if (playerTeleporter.isTeleporting)
        {
            playerTeleporter.PauseSFX();
        }
    }

    public void Resume()
    {
        DialogueManager.Unpause();
        pauseMenuUI.SetActive(false);
        finalPanel.SetActive(false);
        gameIsPaused = false;

        RestorePuzzleStates(); 
        Time.timeScale = 1f;

        if (playerTeleporter.isTeleporting)
        {
            playerTeleporter.UnPauseSFX();
        }
    }

    public void Quit()
    {
        DialogueManager.Unpause();
        DialogueManager.StopAllConversations();
        SceneManager.LoadScene("Menu");
    }

    private void SavePuzzleStates()
    {
        for (int i = 0; i < gameObjects.Length; i++)
        {
            puzzleStates[i] = gameObjects[i].activeSelf; 
        }
    }

    private void RestorePuzzleStates()
    {
        for (int i = 0; i < gameObjects.Length; i++)
        {
            gameObjects[i].SetActive(puzzleStates[i]); 
        }
    }

    public void HidePuzzles()
    {
        foreach (var obj in gameObjects)
        {
            obj.SetActive(false); 
        }
    }
}