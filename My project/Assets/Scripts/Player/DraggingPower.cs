using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DraggingPower : MonoBehaviour
{
    public static DraggingPower Instance { get; set; }
    public GameObject selectedObject;
    float verticalInput;
    float horizontalInput;
    Rigidbody2D _rigidbody;

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
        horizontalInput = Input.GetAxis("Mouse X");
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
            _rigidbody.constraints = RigidbodyConstraints2D.FreezeAll;
            _rigidbody.velocity = Vector3.zero;
            selectedObject = null;
        }
    }
    void Move()
    {
        Cursor.lockState = CursorLockMode.Locked;
        _rigidbody = selectedObject.GetComponent<Rigidbody2D>();
        _rigidbody.constraints = RigidbodyConstraints2D.FreezeRotation;
        var verticalCheck = selectedObject.GetComponent<MoveablePlatform>().Vertical;
        if (verticalCheck)
        {
            float move = Mathf.Lerp(_rigidbody.velocity.y, verticalInput * 15f, Time.fixedDeltaTime * 2f);
            _rigidbody.velocity = new Vector2(0, move);
        }
        else 
        {
            float move = Mathf.Lerp(horizontalInput * 15f, _rigidbody.velocity.x, Time.fixedDeltaTime * 2f);
            _rigidbody.velocity = new Vector2(move, 0);
        }
    }
}
