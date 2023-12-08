using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAudio : MonoBehaviour
{
    [SerializeField] AudioSource clip;

    public void PlayClip()
    {
        clip.Play();
    }
}
