using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Button : MonoBehaviour
{
    HashSet<PlayerMovement> playersInRange = new HashSet<PlayerMovement>();

    [SerializeField] UnityEvent on;
    [SerializeField] UnityEvent off;
    [SerializeField] bool isOn = true;
    [SerializeField] Sprite onSprite;
    [SerializeField] Sprite offSprite;
    new SpriteRenderer renderer;

    void Start()
    {
        renderer = GetComponent<SpriteRenderer>();
        if(isOn)
        {
            renderer.sprite = onSprite;
        }
        else
        {
            renderer.sprite = offSprite;
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
        if (isOn)
        {
            isOn = false;
            renderer.sprite = offSprite;
            on.Invoke();
        }
        else
        {
            isOn = true;
            renderer.sprite = onSprite;
            off.Invoke();
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
