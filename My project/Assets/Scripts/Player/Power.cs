using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Power : MonoBehaviour
{
    [SerializeField] PowerType test;

    void Update()
    {
        switch (test)
        {
            case PowerType.Gentleman:
                break;
            case PowerType.Graffiti:
                break;
            default:
                break;
        }
    }
}
    

public enum PowerType
{
    Graffiti,
    Gentleman
}
