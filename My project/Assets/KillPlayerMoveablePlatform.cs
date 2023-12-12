using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPlayerMoveablePlatform : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player"
            && transform.position.y > collision.transform.position.y
            && DraggingPower.Instance.selectedObject != null)
        {
            ResetScene.Instance.Reset();
            // fa un die pe player
        }
    }
}
