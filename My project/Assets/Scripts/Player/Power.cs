using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Power : MonoBehaviour
{
    [SerializeField] PowerType Type;
    [SerializeField] GameObject test1;
    [SerializeField] GameObject test2;

    void Update()
    {
        CheckForInput();
    }

    void UsePower()
    {
        switch (Type)
        {
            case PowerType.Gentleman:
                {
                    Instantiate(test1);
                    break;
                }
            case PowerType.Graffiti:
                {
                    Instantiate(test2);
                    break;
                }
            default:
                break;
        }
    }

    void CheckForInput()
    {
        if(Input.GetMouseButtonDown(0)) 
        {
            UsePower();
        }
    }
}
    

public enum PowerType
{
    Graffiti,
    Gentleman
}
