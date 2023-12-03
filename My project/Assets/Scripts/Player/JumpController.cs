using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpController : MonoBehaviour
{
    [Header("Jump Variables")]
    [SerializeField] float jumpPower;

    Vector2 vectorGravity;
    Rigidbody2D _rigidbody;
    bool isJumping;
    int jumpCounter;
    int jumpBufferCounter;
    int coyoteTimeCounter;
    

    void Start()
    {
        vectorGravity = new Vector2(0, -Physics2D.gravity.y);
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        ReadJumpInput();    
    }

    void ReadJumpInput()
    {
        if(jumpBufferCounter > 0 && coyoteTimeCounter > 0)
        {
            _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, jumpPower);
            isJumping = true;
            jumpCounter = 0;
            jumpBufferCounter = 0;
        }
    }
}
