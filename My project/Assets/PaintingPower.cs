using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintingPower : MonoBehaviour
{
    public GameObject selectedObject;

    void Update()
    {
        CheckForAimInput();
    }

    void CheckForAimInput()
    {
        if (Input.GetMouseButton(1))
        {
            PaintPlatform();
        }
    }

    void PaintPlatform()
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Collider2D targetObject = Physics2D.OverlapPoint(mousePosition);
        if (targetObject && targetObject.tag == "Art") 
        {
            if(Input.GetMouseButton(0)) 
            {
                Destroy(targetObject.gameObject);
            }
        }
    }
}
