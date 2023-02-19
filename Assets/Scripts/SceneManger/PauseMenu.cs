using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    public PlayerMovement playerMovement;
    public PlayerHealth playerHealth;
    public Shoot playerShoot;

    public SceneLoader sceneLoader;
    public static bool isPaused;
    
    void Start()
    {
        pauseMenu.SetActive(false);
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) && playerHealth.currHp > 0)
        {
            if (isPaused)
            {
                ResumeGame();
            }

            else
            {
                PauseGame();
            }
        }
    }

    public void PauseGame()
    {
        pauseMenu.SetActive(true);
        playerMovement.enabled = false;
        playerShoot.enabled = false;

        Time.timeScale = 0f;
        isPaused = true;
    }

    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        playerMovement.enabled = true;
        playerShoot.enabled = true;
        Time.timeScale = 1f;
        isPaused = false;
    }

    public void MainMenu()
    {
        Time.timeScale = 1f;
        sceneLoader.LoadNextLevel("Title Screen");
        isPaused = false;
    }

    public void QuitGame()
    {
        Debug.Log("Game Quit");
        //Application.Quit;
    }
}
