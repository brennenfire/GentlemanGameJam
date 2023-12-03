using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Power : MonoBehaviour
{
    [SerializeField] PowerType test;

    void Update()
    {
        CheckForInput();
        UsePower();
    }

    private void UsePower()
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

    void CheckForInput()
    {
        
    }
}
    

public enum PowerType
{
    Graffiti,
    Gentleman
}
