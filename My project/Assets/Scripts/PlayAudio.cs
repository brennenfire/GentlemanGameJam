using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAudio : MonoBehaviour
{
    [SerializeField] List<AudioClip> clips;

    public void PlayClip(int clipNumber)
    {
        GetComponent<AudioSource>().PlayOneShot(clips[clipNumber]);
    }
}
