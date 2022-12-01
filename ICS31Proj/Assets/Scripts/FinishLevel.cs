using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLevel : MonoBehaviour
{
    [SerializeField] GameObject finishLevel;
    [SerializeField] GameObject gameUI;
    private int nextLevel;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            CameraController.Deactivate();
            Time.timeScale = 0f;
            gameUI.SetActive(false);
            finishLevel.SetActive(true);
            if (SceneManager.GetActiveScene().buildIndex < 2)
            {
                nextLevel = SceneManager.GetActiveScene().buildIndex + 1;
                
            }
            else
            {
                nextLevel = 0;
            }
            PlayerPrefs.SetInt("Level", nextLevel);
        }
    }
    public void NextLevel()
    {
        CameraController.Activate();
        Time.timeScale = 1f;
        gameUI.SetActive(true);
        finishLevel.SetActive(false);
        SceneManager.LoadScene(nextLevel);
    }
    public void MainMenu(int sceneID)
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(sceneID);
    }
}
