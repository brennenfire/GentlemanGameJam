using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void LoadGame(int levelNumber)
    {
        SceneManager.LoadScene(levelNumber);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
