using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAnimation : MonoBehaviour
{
    Animator animator;

    [ContextMenu("play")]
    void PlayAnim()
    {
        GetComponent<Animator>().SetBool("Play", true);
    }
}
