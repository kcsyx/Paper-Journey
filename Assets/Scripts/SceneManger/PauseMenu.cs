using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    public PlayerMovement playerMovement;
    public Shoot playerShoot;

    public SceneLoader sceneLoader;
    public static bool isPaused;
    public bool canPause = true;

    public Slider _bgmSlider, _sfxSlider;

    private void Awake()
    {
        _bgmSlider.value = AudioManager.bgmVol;
        _sfxSlider.value = AudioManager.sfxVol;
    }
    void Start()
    {
        pauseMenu.SetActive(false);
    }

    void Update()
    {

        if (canPause)
        {
            if (Input.GetKeyDown(KeyCode.Escape) && PlayerHealth.currHp > 0)
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

    }

    public void PauseGame()
    {
        AudioManager.instance.PlaySFX("menu_open");
        pauseMenu.SetActive(true);
        playerMovement.canMove = false;
        playerMovement.enabled = false;
        playerShoot.enabled = false;

        Time.timeScale = 0f;
        isPaused = true;
    }

    public void ResumeGame()
    {
        AudioManager.instance.PlaySFX("menu_open");
        pauseMenu.SetActive(false);
        playerMovement.canMove = true;
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
        Application.Quit();
    }

    public void BGMVolume()
    {
        AudioManager.instance.BGMVolume(_bgmSlider.value);
    }

    public void SFXVolume()
    {
        AudioManager.instance.SFXVolume(_sfxSlider.value);
    }
}
