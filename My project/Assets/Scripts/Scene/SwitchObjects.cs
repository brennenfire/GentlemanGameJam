using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchObjects : MonoBehaviour
{
    public static SwitchObjects Instance { get; private set; }
    GameObject[] gentlemanObjects;
    GameObject[] graffitiObjects;

    void Awake()
    {
        Instance = this;
        gentlemanObjects = GameObject.FindGameObjectsWithTag("Gentleman");
        graffitiObjects = GameObject.FindGameObjectsWithTag("Graffiti");
    }

    public void Switch(string name)
    {
        if (name == "Gentleman")
        {
            foreach (var item in gentlemanObjects)
            {
                item.GetComponent<SwitchIndividualObject>().SwitchOn();
            }

            foreach (var item in graffitiObjects)
            {
                item.GetComponent<SwitchIndividualObject>().SwitchOff();
            }
        }

        if (name == "Graffiti")
        {
            foreach (var item in graffitiObjects)
            {
                item.GetComponent<SwitchIndividualObject>().SwitchOn();
            }

            foreach (var item in gentlemanObjects)
            {
                item.GetComponent<SwitchIndividualObject>().SwitchOff();
            }
        }
    }
}
