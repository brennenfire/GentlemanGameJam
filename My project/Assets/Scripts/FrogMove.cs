using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogMove : MonoBehaviour
{
    [SerializeField] Vector3 targetDestination;
    [SerializeField] bool end = false;

    void Update()
    {
        if (transform.position != targetDestination)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetDestination, 3 * Time.fixedDeltaTime);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(end)
        {
            Application.Quit();
            Debug.Log("end");
        }
    }
}
