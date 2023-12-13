using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveablePlatform : MonoBehaviour
{
    [SerializeField] float limit = 2f;
    [SerializeField] bool vertical;

    Vector3 initialPosition;

    public bool Vertical => vertical;

    void Start()
    {
        initialPosition = transform.localPosition;    
    }

    void Update()
    {
        if (vertical)
        {
            if (transform.localPosition.y > limit)
            {
                transform.localPosition = new Vector3(transform.localPosition.x, limit, transform.localPosition.z);
            }
            if (transform.localPosition.y < -limit)
            {
                transform.localPosition = new Vector3(transform.localPosition.x, -limit, transform.localPosition.z);
            }
        }
        else
        {
            if (transform.localPosition.x > limit)
            {
                transform.localPosition = new Vector3(limit, transform.localPosition.y, transform.localPosition.z);
            }
            if (transform.localPosition.x < -limit)
            {
                transform.localPosition = new Vector3(-limit, transform.localPosition.y, transform.localPosition.z);
            }
        }
    }

}
