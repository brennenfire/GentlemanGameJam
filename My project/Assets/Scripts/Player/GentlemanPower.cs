using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GentlemanPower : MonoBehaviour
{
    public GameObject selectedObject;
    Vector2 offset;
    void Update()
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (Input.GetMouseButtonDown(0))
        {
            Collider2D targetObject = Physics2D.OverlapPoint(mousePosition);
            if (targetObject && targetObject.tag == "Gentleman")
            {
                selectedObject = targetObject.transform.gameObject;
                offset = new Vector2(0, selectedObject.transform.position.y) - new Vector2(0, mousePosition.y);
            }
        }
        if (selectedObject)
        {
            selectedObject.transform.position = new Vector2(selectedObject.transform.position.x, mousePosition.y) + offset;
        }
        if (Input.GetMouseButtonUp(0) && selectedObject)
        {
            selectedObject = null;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision != null) 
        {
            Debug.Log("test collision");
        }        
    }
}
