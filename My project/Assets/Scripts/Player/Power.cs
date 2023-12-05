using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Power : MonoBehaviour
{
    [SerializeField] PowerType Type;
    [SerializeField] GameObject GePower;
    [SerializeField] GameObject GrPower;

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
                    Instantiate(GePower, transform.position, Quaternion.identity);
                    break;
                }
            case PowerType.Graffiti:
                {
                    Instantiate(GrPower, transform.position, Quaternion.identity);
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
