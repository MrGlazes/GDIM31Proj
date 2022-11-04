using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        //Loads the scene named "Game" in our "ScenesInBuild"
        SceneManager.LoadScene("Game");
    }

    public void QuitGame()
    {
        Debug.Log("Game has been Quit");
        Application.Quit();
    }

}
