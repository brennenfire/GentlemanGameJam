using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float speed = 5f;
    //[SerializeField] Transform leftSensor;
    //[SerializeField] Transform rightSensor;
    //[SerializeField] float wallSlideSpeed = 1f;

    Rigidbody2D _rigidbody;
    float horizontalInput;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        GetHorizontalInput();
        //if(ShouldSlide())
        //{
            //Slide();
        //}
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
            float newHorizontal = Mathf.Lerp(_rigidbody.velocity.x, horizontalInput * speed, Time.fixedDeltaTime * 20f);
            _rigidbody.velocity = new Vector2(newHorizontal, _rigidbody.velocity.y);
        }
    }

    //bool ShouldSlide()
    //{

    //    if (JumpController.Instance.IsGrounded())
    //    {
    //        return false;
    //    }

    //    if (_rigidbody.velocity.y > 0)
    //    {
    //        return false;
    //    }

    //    if (horizontalInput < 0)
    //    {
    //        var hit = Physics2D.OverlapCircle(leftSensor.position, 0.1f);
    //        if (hit != false && hit.CompareTag("Wall"))
    //        {
    //            return true;
    //        }
    //    }
    //    if (horizontalInput > 0)
    //    {
    //        var hit = Physics2D.OverlapCircle(rightSensor.position, 0.1f);
    //        if (hit != false && hit.CompareTag("Wall"))
    //        {
    //            return true;
    //        }
    //    }
    //    return false;
    //}

    //void Slide()
    //{
    //    _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, -wallSlideSpeed);
    //}

}
