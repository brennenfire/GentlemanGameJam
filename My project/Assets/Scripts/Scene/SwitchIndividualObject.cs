using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchIndividualObject : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    Collider2D collision;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        collision = GetComponent<Collider2D>();
    }

    public void SwitchOff()
    {
        collision.enabled = false;
        spriteRenderer.color = new Color(1f, 1f, 1f, 0.25f);
    }

    public void SwitchOn()
    {
        collision.enabled = true;
        spriteRenderer.color = new Color(1f, 1f, 1f, 1f);
    }
}
