using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float speed = 5f;

    Rigidbody2D _rigidbody;
    float horizontalInput;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        GetHorizontalInput();
        Movement();
    }

    void GetHorizontalInput()
    {
        horizontalInput = Input.GetAxis("Horizontal");
    }

    void Movement()
    {
        if(horizontalInput != 0) 
        {
            float newHorizontal = Mathf.Lerp(_rigidbody.velocity.x, horizontalInput * speed, Time.fixedDeltaTime * 15f);
            _rigidbody.velocity = new Vector2(newHorizontal, _rigidbody.velocity.y);
        }
    }
    
}
