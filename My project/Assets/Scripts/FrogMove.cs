using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogMove : MonoBehaviour
{
    [SerializeField] Vector3 targetDestination;

    void Update()
    {
        if (transform.position != targetDestination)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetDestination, 1.5f * Time.fixedDeltaTime);
        }
    }
}
