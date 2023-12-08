using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField] Vector3 limit;
    Vector3 positionTest;
    Vector3 positionTest1;

    [SerializeField] float speed = 5f;

    bool moving = true;

    void Start()
    {
        positionTest = transform.position + limit;
        positionTest1 = transform.position - limit;
    }

    void Update()
    {
        var step = speed * Time.deltaTime;
        CheckPosition();
        MovePositive(step);
        MoveNegative(step);
    }

    void CheckPosition()
    {
        if (transform.position == positionTest)
            moving = false;
        else if (transform.position == positionTest1)
            moving = true;
    }

    void MovePositive(float step)
    {
        if (moving)
        {
            transform.position = Vector3.MoveTowards(transform.position, positionTest, step);
        }
    }

    void MoveNegative(float step)
    {
        if (!moving)
        {
            transform.position = Vector3.MoveTowards(transform.position, positionTest1, step);
        }
    }
}
