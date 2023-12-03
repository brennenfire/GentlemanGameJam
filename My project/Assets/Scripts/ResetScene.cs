using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetScene : MonoBehaviour
{
    public ResetScene Instance { get; private set; }

    void Awake()
    {
        Instance = this;
    }

    [ContextMenu("Reset")]
    public void Reset()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
