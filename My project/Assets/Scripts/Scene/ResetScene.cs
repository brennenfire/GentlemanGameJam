using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetScene : MonoBehaviour
{
    public static ResetScene Instance { get; private set; }

    [SerializeField] GameObject inTransition;
    [SerializeField] GameObject outTransition1;
    [SerializeField] GameObject outTransition2;

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
        int number = UnityEngine.Random.Range(0, 2);
        GameObject transition;
        if(number == 0)
        {
            transition = outTransition1;
        }
        else
        {
            transition = outTransition2;
        }
        transition.SetActive(true);
        transition.GetComponent<Animator>().SetBool("Play", true);
        StartCoroutine(PlayAnimations());
    }

    IEnumerator PlayAnimations()
    {
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
