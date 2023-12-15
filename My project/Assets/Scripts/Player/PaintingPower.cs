using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintingPower : MonoBehaviour
{
    [SerializeField] GameObject painting;
    List<GameObject> paintingList = new List<GameObject>();
    int uses;

    public static PaintingPower Instance { get; private set; }

    void Awake()
    {
        Instance = this;
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
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Collider2D targetObject = Physics2D.OverlapPoint(mousePosition);
        if (targetObject && targetObject.tag == "Art") 
        {
            if(Input.GetMouseButton(0)) 
            {
                if(paintingList.Count >= uses)
                {
                    RemoveFromList();
                }
                var paint = Instantiate(painting, targetObject.transform.position + new Vector3(0, 0f, 0), Quaternion.identity);
                paintingList.Add(paint);
                GraffitiPower.Instance.RemoveFromList(targetObject.gameObject);
            }
        }
    }

    public void RemoveFromList()
    {
        Destroy(paintingList[0]);
        paintingList.RemoveAt(0);
    }
}
