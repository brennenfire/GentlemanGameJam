using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatformCheck : MonoBehaviour
{
    public GameObject character;

    Rigidbody2D rig;

    float speed = 10f;

    bool moveWithPlatform = false;
    bool moveRight = false;

    Vector2 newPosition;
    Vector2 oldPosition;

    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        newPosition = transform.position;

        /*
        if (moveRight == true)
        {
            rig.velocity = new Vector2(speed, 0);

            if ((transform.position.x) >= 2f)
            {
                moveRight = false;
            }
        }
        else
        {
            rig.velocity = new Vector2(-speed, 0);

            if ((transform.position.x) <= -2f)
            {
                moveRight = true;
            }
        }
        */

        float difference = newPosition.x - oldPosition.x;

        oldPosition = transform.position;

        if (moveWithPlatform == true)
        {
            character.transform.position += Vector3.right * difference * Time.deltaTime;
        }
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            moveWithPlatform = true;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            moveWithPlatform = false;
        }
    }
}
