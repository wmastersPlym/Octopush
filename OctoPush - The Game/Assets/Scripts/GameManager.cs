﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum GameState { MAIN_MENU, INFO_PAGE, SALEM, PUCKHUNT }

public class GameManager : MonoBehaviour
{
    protected GameManager() { }
    private static GameManager instance = null;

    public GameState gameState { get; private set; }

    public static GameManager Instance
    {
        get
        {
            if (GameManager.instance == null)
            {
                DontDestroyOnLoad(GameManager.instance);
                GameManager.instance = new GameManager();
            }
            return GameManager.instance;
        }
    }

    public void OnStateChange()
    {
        if (gameState == GameState.SALEM)
        {
            SceneManager.LoadScene("Salem");
        }
        else if (gameState == GameState.MAIN_MENU)
        {
            SceneManager.LoadScene("MainMenu");
        }
        else if (gameState == GameState.INFO_PAGE)
        {
            SceneManager.LoadScene("InfoPage");
        }
        else if (gameState == GameState.PUCKHUNT)
        {
            SceneManager.LoadScene("PuckHunt");
        }
    }

    public void SetGameState(GameState state)
    {
        this.gameState = state;
        OnStateChange();
    }

    public void OnApplicationQuit()
    {
        GameManager.instance = null;
    }

    public void SetStateSalem()
    {
        SetGameState(GameState.SALEM);
    }

    public void SetStatePuckHunt()
    {
        SetGameState(GameState.PUCKHUNT);
    }

    public void SetStateInfoPage()
    {
        SetGameState(GameState.INFO_PAGE);
    }

    public void SetStateMainMenu()
    {
        SetGameState(GameState.MAIN_MENU);
    }

    public void Quit()
    {
        Application.Quit();
    }


    
}
