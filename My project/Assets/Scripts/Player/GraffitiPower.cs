using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraffitiPower : MonoBehaviour
{
    [SerializeField] GameObject Graffiti;
    [SerializeField] int uses = 1;

    List<GameObject> graffitis = new List<GameObject>();

    public static GraffitiPower Instance { get; private set; }

    void Awake()
    {
        Instance = this;    
    }

    void Update()
    {
        CheckForInput();
    }

    void CheckForInput()
    {
        if (Input.GetKeyUp(KeyCode.E))
        {
            UsePower();
        }
    }

    void UsePower()
    {
        if (graffitis.Count >= uses)
        {
            Destroy(graffitis[0]);
            graffitis.RemoveAt(0);
        }
        var test = Instantiate(Graffiti, transform.position + new Vector3(0f, 1f, 0f), Quaternion.identity);
        graffitis.Add(test);
    }
    
}
