using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetScene : MonoBehaviour
{
    public ResetScene Instance { get; private set; }

    [SerializeField] GameObject inTransition;
    [SerializeField] GameObject outTransition;

    void Awake()
    {
        Instance = this;
        inTransition.SetActive(true);
        inTransition.GetComponent<Animator>().SetBool("Play", true);
    }

    [ContextMenu("Reset")]
    public void Reset()
    {
        outTransition.SetActive(true);
        StartCoroutine(PlayAnimations());
    }

    IEnumerator PlayAnimations()
    {
        outTransition.GetComponent<Animator>().SetBool("Play", true);
        yield return new WaitForSeconds(0.15f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
