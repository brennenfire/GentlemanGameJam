using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveablePlatform : MonoBehaviour
{
    Vector3 initialPosition;
    [SerializeField] float limit = 2f;

    void Start()
    {
        initialPosition = transform.position;    
    }

    void Update()
    {
        if (transform.position.y > limit)
        {
            transform.position = new Vector3(transform.position.x, limit, transform.position.z);
        }
        if (transform.position.y < -limit)
        {
            transform.position = new Vector3(transform.position.x, -limit, transform.position.z);
        }
    }
}
