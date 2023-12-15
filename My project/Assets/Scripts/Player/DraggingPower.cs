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
    [SerializeField] float stupidFuckingThing = 5f;

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
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Collider2D targetObject = Physics2D.OverlapPoint(mousePosition);
        if (Input.GetMouseButton(0))
        {
            if (targetObject && targetObject.GetComponent<MoveablePlatform>() != null)
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

    public void StopDragging()
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
            float move = Mathf.Lerp(_rigidbody.velocity.y, verticalInput * 3f, Time.fixedDeltaTime * stupidFuckingThing);
            _rigidbody.velocity = new Vector2(0, move);
        }
        else 
        {
            float move = Mathf.Lerp(horizontalInput * 3f, _rigidbody.velocity.x, Time.fixedDeltaTime * stupidFuckingThing);
            _rigidbody.velocity = new Vector2(move, 0);
        }
    }
}
