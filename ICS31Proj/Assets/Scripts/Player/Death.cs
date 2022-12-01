using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Death : MonoBehaviour
{
    [SerializeField] private Animator anime;
    [SerializeField] private GameObject deathMenu;
    [SerializeField] private GameObject gameUI;

    private void DeathMenu()
    {
        Time.timeScale = 0f;
        gameUI.SetActive(false);
        deathMenu.SetActive(true);
    }

    public void Retry()
    {
        Time.timeScale = 1f;
        gameUI.SetActive(true);
        deathMenu.SetActive(false);
        SceneManager.LoadScene(PlayerPrefs.GetInt("Level"));
    }

    public void MainMenu()
    {
        Time.timeScale = 1f;
        deathMenu.SetActive(false);
        SceneManager.LoadScene(0);
    }
}
