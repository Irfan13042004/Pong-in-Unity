sing System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.Audio;
using UnityEditor;
using System.Runtime.CompilerServices;

// This Script Takes care of the most UI Functions


public class Starter : MonoBehaviour
{
    public static bool _isGamePaused = false;
    public GameObject _menuUI;

   
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (_isGamePaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
        
    }

    // Starts the game by Loading bthe Scene 1. (Scene 0 is the Menu)
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    // Quits the Application
    public void ExitGame()
    {
        Application.Quit();
        Debug.Log("Quit Game!...");
    }

    // Back to Main Menu
    public void Back()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }

    // Resumes The Paused Game
    public void Resume()
    {
        _menuUI.SetActive(false);
        Time.timeScale = 1f;
        _isGamePaused = false;
    }
    
    // Pause The Running Game
    public void Pause()
    {
        _menuUI.SetActive(true);
        Time.timeScale = 0f;
        _isGamePaused = true;
    }
