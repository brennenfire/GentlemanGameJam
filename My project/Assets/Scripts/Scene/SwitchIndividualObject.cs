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
        GetComponent<Collider2D>().enabled = false;
        GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0.25f);
    }
    
    public void SwitchOn()
    {
        GetComponent<Collider2D>().enabled = true;
        GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
    }
}
