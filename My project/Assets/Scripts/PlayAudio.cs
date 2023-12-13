using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAudio : MonoBehaviour
{
    [SerializeField] List<AudioSource> clips;

    public void PlayClip(int clipNumber)
    {
        clips[clipNumber].Play();
    }
}
