using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField] Vector3 limit;
    Vector3 positiveLimit;
    Vector3 negativeLimit;

    [SerializeField] float speed = 5f;

    bool moving = true;

    void Start()
    {
        positiveLimit = transform.position + limit;
        negativeLimit = transform.position - limit;
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
        if (transform.position == positiveLimit)
            moving = false;
        else if (transform.position == negativeLimit)
            moving = true;
    }

    void MovePositive(float step)
    {
        if (moving)
        {
            transform.position = Vector3.MoveTowards(transform.position, positiveLimit, step);
        }
    }

    void MoveNegative(float step)
    {
        if (!moving)
        {
            transform.position = Vector3.MoveTowards(transform.position, negativeLimit, step);
        }
    }
}
