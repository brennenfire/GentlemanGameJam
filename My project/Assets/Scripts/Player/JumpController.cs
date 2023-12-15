using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpController : MonoBehaviour
{
    [SerializeField] Transform groundCheck;
    [SerializeField] LayerMask groundLayer;
    [Header("Jump Variables")]
    [SerializeField] float jumpPower = 5f;
    [SerializeField] float fallMultiplier = 5f;
    [SerializeField] float jumpTime = 1f;
    [SerializeField] float jumpMultiplier;

    Vector2 vectorGravity;
    Rigidbody2D _rigidbody;
    bool isJumping;
    float jumpCounter;
    float jumpBufferCounter;
    float coyoteTimeCounter;

    public static JumpController Instance { get; set; }

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        vectorGravity = new Vector2(0, -Physics2D.gravity.y);
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        ReadJumpInput();
        StopJump();
        DoJump();
        CoyoteTimer();
        JumpBuffer();

        if(_rigidbody.velocity.y < 0)
        {
            _rigidbody.velocity -= fallMultiplier * Time.deltaTime * vectorGravity;
        }
    }

    void JumpBuffer()
    {
        if(Input.GetButtonDown("Jump"))
        {
            jumpBufferCounter = 0.2f;
        }
        else
        {
            jumpBufferCounter -= Time.deltaTime;
        }
    }

    void CoyoteTimer()
    {
        if(IsGrounded())
        {
            coyoteTimeCounter = .3f;
        }
        else
        {
            jumpBufferCounter -= Time.deltaTime;
        }
    }

    public bool IsGrounded()
    {
        if(Physics2D.OverlapCircle(groundCheck.position, 0.25f, groundLayer))
            return true;
        else
            return false;
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

    void StopJump()
    {
        if(Input.GetButtonUp("Jump"))
        {
            isJumping = false;
            jumpCounter = 0;

            if(_rigidbody.velocity.y > 0f)
            {
                _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, _rigidbody.velocity.y * 0.6f);
            }

            coyoteTimeCounter = 0;
        }

    }

    void DoJump()
    {
        if(_rigidbody.velocity.y > 0 && isJumping)
        {
            jumpCounter += Time.deltaTime;
            if(jumpCounter > jumpTime)
            {
                isJumping = false;
            }

            float t = jumpCounter / jumpTime;
            float currentJumpM = jumpMultiplier;

            if(t > 0.5f)
            {
                currentJumpM = jumpMultiplier * (1 - t);
            }

            _rigidbody.velocity += vectorGravity * currentJumpM * Time.deltaTime;
        }
    }
}
