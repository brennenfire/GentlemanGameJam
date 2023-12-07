using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GentlemanPower : MonoBehaviour
{
    public static GentlemanPower Instance { get; set; }
    public GameObject selectedObject;
    float verticalInput;

    void Awake()
    {
        Instance = this;
    }

    void Update()
    {
        verticalInput = Input.GetAxis("Vertical");
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (Input.GetMouseButtonDown(0))
        {
            Collider2D targetObject = Physics2D.OverlapPoint(mousePosition);
            if (targetObject && targetObject.tag == "Gentleman")
            {
                selectedObject = targetObject.transform.gameObject;
            }
        }
        if (selectedObject)
        {
            CheckAimInput();
        }
        if (Input.GetMouseButtonUp(0) && selectedObject) 
        {
            selectedObject = null;
        }
    }

    void CheckAimInput()
    {
        if (Input.GetMouseButton(1))
            Move();
    }

    void Move()
    {
        var _rigidbody = selectedObject.GetComponent<Rigidbody2D>();
        float move = Mathf.Lerp(_rigidbody.velocity.y, verticalInput * 5f, Time.fixedDeltaTime * 2f);
        _rigidbody.velocity = new Vector2(0, move);
    }
}
