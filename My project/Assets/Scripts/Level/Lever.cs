using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Lever : MonoBehaviour
{
    HashSet<PlayerMovement> playersInRange = new HashSet<PlayerMovement>();

    [SerializeField] UnityEvent onDown;
    [SerializeField] UnityEvent onUp;
    [SerializeField] bool isUp = true;
    [SerializeField] Sprite upSprite;
    [SerializeField] Sprite downSprite;
    new SpriteRenderer renderer;

    void Start()
    {
        renderer = GetComponent<SpriteRenderer>();
        if(isUp)
        {
            renderer.sprite = upSprite;
        }
        else
        {
            renderer.sprite = downSprite;
        }
    }

    void Update()
    {
        if(playersInRange.Count > 0) 
        {
            if(Input.GetKeyDown(KeyCode.E))
            {
                //TurnLever();
                StartCoroutine(WaitToSwitch());
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            playersInRange.Add(collision.GetComponent<PlayerMovement>());
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            playersInRange.Remove(collision.GetComponent<PlayerMovement>());
    }

    IEnumerator WaitToSwitch()
    {
        yield return new WaitForSeconds(0.5f);
        if (isUp)
        {
            isUp = false;
            renderer.sprite = downSprite;
            onDown.Invoke();
        }
        else
        {
            isUp = true;
            renderer.sprite = upSprite;
            onUp.Invoke();
        }
    }

    /*
    void TurnLever()
    {
        switch (isUp)
        {
            case true:
                {
                    StartCoroutine(WaitToSwitch());
                    break;
                }
            case false:
                {
                    StartCoroutine(WaitToSwitch());
                    break;
                }
        }
    }
    */

    public void SendLog()
    {
        Debug.Log("testing");
    }
}
