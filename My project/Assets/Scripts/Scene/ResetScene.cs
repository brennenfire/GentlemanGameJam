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
        if(inTransition != null) 
        {
            inTransition.SetActive(true);
            inTransition.GetComponent<Animator>().SetBool("Play", true);
        }
    }

    [ContextMenu("Reset")]
    public void Reset()
    {
        outTransition.SetActive(true);
        outTransition.GetComponent<Animator>().SetBool("Play", true);
        StartCoroutine(PlayAnimations());
    }

    IEnumerator PlayAnimations()
    {
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
