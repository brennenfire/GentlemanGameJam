using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchIndividualObject : MonoBehaviour
{
    //SpriteRenderer spriteRenderer;
    //Collider2D collision;

    //void Start()
    //{
        //spriteRenderer = GetComponent<SpriteRenderer>();
        //collision = GetComponent<Collider2D>();

    //}

    public void SwitchOff()
    {
        var colliders = GetComponents<Collider2D>();
        foreach (var collider in colliders)
        {
            collider.enabled = false;
        }
        GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0.25f);
    }
    
    public void SwitchOn()
    {
        var colliders = GetComponents<Collider2D>();
        foreach (var collider in colliders)
        {
            collider.enabled = true;
        }
        GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
    }
}
