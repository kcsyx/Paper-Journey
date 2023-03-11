using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public Animator transition;
    public float delay = 1f;
    public Button btn;
    public string destination;

    void Start()
    {
        btn.onClick.AddListener(BtnOnClick);
        btn.interactable = true;
    }

    //handles click events for buttons
    private void BtnOnClick()
    {
        AudioManager.instance.PlaySFX("menu_open");
        btn.interactable = false;
        LoadNextLevel(destination);
    }

    public void LoadNextLevel(string nxtLvl)
    {
        StartCoroutine(LoadLevel(nxtLvl));
    }

    public void RestartCurrentLevel(string currentLvl)
    {
        AudioManager.instance.PlaySFX("menu_open");
        StartCoroutine(RestartLevel(currentLvl));
    }

    IEnumerator RestartLevel(string currentLvl)
    {
        Time.timeScale = 1f;

        transition.SetTrigger("Start");
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(currentLvl);
        PlayerHealth.maxHp = 3;
        PlayerHealth.currHp = PlayerHealth.maxHp;
    }
    IEnumerator LoadLevel(string LevelName)
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(delay);

        SceneManager.LoadScene(LevelName);
    }

    public void QuitGame()
    {
        Debug.Log("Game Quit");
        Application.Quit();
    }
}
