using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintingPower : MonoBehaviour
{
    [SerializeField] GameObject painting;
    List<GameObject> paintingList = new List<GameObject>();
    int uses;

    void Start()
    {
        uses = GraffitiPower.Instance.Uses;    
    }

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
                if(paintingList.Count >= uses) 
                {
                    paintingList.RemoveAt(0);
                    Destroy(paintingList[0]);
                }
                var paint = Instantiate(painting, targetObject.transform.position + new Vector3(0, 1f, 0), Quaternion.identity);
                paintingList.Add(paint);
                Destroy(targetObject.gameObject);
            }
        }
    }
}
