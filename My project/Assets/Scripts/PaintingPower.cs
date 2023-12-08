using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintingPower : MonoBehaviour
{
    [SerializeField] GameObject painting;

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
                Instantiate(painting, targetObject.transform.position + new Vector3(0, 1f, 0), Quaternion.identity);
                Destroy(targetObject.gameObject);
            }
        }
    }
}
