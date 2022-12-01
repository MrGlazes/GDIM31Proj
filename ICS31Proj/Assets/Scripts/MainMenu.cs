using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        PlayerPrefs.DeleteAll();
        PlayerPrefs.SetInt("Level", 1);
        //Loads the scene named "Game" in our "ScenesInBuild"
        SceneManager.LoadScene(PlayerPrefs.GetInt("Level"));
        CameraController.Activate();
    }
    public void LoadGame()
    {
        //Loads the scene named "Game" in our "ScenesInBuild"
        SceneManager.LoadScene(PlayerPrefs.GetInt("Level"));
        CameraController.Activate();
    }

    public void QuitGame()
    {
        Debug.Log("Game has been Quit");
        Application.Quit();
    }

}
