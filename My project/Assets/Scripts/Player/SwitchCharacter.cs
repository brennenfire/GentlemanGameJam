using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwitchCharacter : MonoBehaviour
{
    [SerializeField] GameObject Graffiti;
    [SerializeField] GameObject Gentleman;
    [SerializeField] GameObject GentlemanUI;
    [SerializeField] GameObject GraffitiUI;


    void Start()
    {
        CheckOnStart();
    }

    void CheckOnStart()
    {
        if (Graffiti.activeSelf)
        {
            SwitchObjects.Instance.Switch("Graffiti");
            GraffitiUI.SetActive(false);
            GentlemanUI.SetActive(true);
        }
        else
        {
            SwitchObjects.Instance.Switch("Gentleman");
            GraffitiUI.SetActive(true);
            GentlemanUI.SetActive(false);
        }
    }

    [ContextMenu("Switch")]
    public void Switch()
    {
        StartCoroutine(Wait());
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(1f);
        Check();
    }

    void Check()
    {
        if (Graffiti.activeSelf)
        {
            SwitchObjects.Instance.Switch("Gentleman");
            Gentleman.SetActive(true);
            GentlemanUI.SetActive(false);
            Graffiti.SetActive(false);
            GraffitiUI.SetActive(true);
        }
        else
        {
            SwitchObjects.Instance.Switch("Graffiti");
            Gentleman.SetActive(false);
            GentlemanUI.SetActive(true);
            Graffiti.SetActive(true);
            GraffitiUI.SetActive(false);
        }
    }
}
