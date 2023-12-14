using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField] TMP_InputField input;

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void LoadGame()
    {
        SceneManager.LoadScene(int.Parse(input.text));
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
