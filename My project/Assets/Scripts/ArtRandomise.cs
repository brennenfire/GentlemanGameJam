using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArtRandomise : MonoBehaviour
{
    [SerializeField] Sprite art1;
    [SerializeField] Sprite art2;
    [SerializeField] SpriteRenderer art;

    void Awake()
    {
        int number = UnityEngine.Random.Range(0, 2);
        if (number == 0)
        {
            art.sprite = art1;
        }
        else
        {
            art.sprite = art2;
        }
    }
}
