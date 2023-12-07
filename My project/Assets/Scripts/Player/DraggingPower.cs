using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DraggingPower : MonoBehaviour
{
    public static DraggingPower Instance { get; set; }
    public GameObject selectedObject;
    float verticalInput;

    void Awake()
    {
        Instance = this;
    }

    void Update()
    {
        CheckForAimInput();
        CheckToStop();
    }

    void CheckForAimInput()
    {
        if (Input.GetMouseButton(1))
        {
            HandleDragging();
        }
    }

    void HandleDragging()
    {
        verticalInput = Input.GetAxis("Mouse Y");
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (Input.GetMouseButton(0))
        {
            Collider2D targetObject = Physics2D.OverlapPoint(mousePosition);
            if (targetObject && targetObject.tag == "Gentleman")
            {
                selectedObject = targetObject.transform.gameObject;
            }
        }
        if (selectedObject)
        {
            Move();
        }
    }

    void CheckToStop()
    {
        if (Input.GetMouseButtonUp(0) || Input.GetMouseButtonUp(1))
        {
            StopDragging();
        }
    }

    void StopDragging()
    {
        if(selectedObject) 
        {
            Cursor.lockState = CursorLockMode.None;
            selectedObject.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
            selectedObject = null;
        }
    }

    /*
    void CheckAimInput()
    {
        if (Input.GetMouseButton(1))
            Move();
    }
    */

    void Move()
    {
        Cursor.lockState = CursorLockMode.Locked;
        var _rigidbody = selectedObject.GetComponent<Rigidbody2D>();
        float move = Mathf.Lerp(_rigidbody.velocity.y, verticalInput * 15f, Time.fixedDeltaTime * 2f);
        // try calculating how much its moved here
        /*
        if (pos.y >= 5)
        {
            pos = new Vector3(pos.x, 5, pos.z);
        }
        if (pos.y <= -5)
        {
            pos = new Vector3(pos.x, -5, pos.z);
        }
        */
        if (selectedObject.transform.position.y > 5f)
        {
            selectedObject.transform.position = new Vector3(selectedObject.transform.position.x, 5f, selectedObject.transform.position.z);
        }
        if (selectedObject.transform.position.y < -5f)
        {
            selectedObject.transform.position = new Vector3(selectedObject.transform.position.x, -5f, selectedObject.transform.position.z);
        }
        _rigidbody.velocity = new Vector2(0, move);
    }
}
