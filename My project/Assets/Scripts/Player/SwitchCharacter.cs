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
    [SerializeField] GameObject Erase;
    [SerializeField] GameObject Draw;
    [SerializeField] GameObject Rip;
    [SerializeField] GameObject Pop;

    bool canSwitch = true;

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
        if(canSwitch)
        {
            StartCoroutine(Wait());
        }
        else
        {
            return;
        }
    }

    IEnumerator Wait()
    {
        canSwitch = false;
        StartCoroutine(PlayAnimations());
        yield return new WaitForSeconds(0.1f);
        canSwitch = true;
        Check();
    }

    IEnumerator PlayAnimations()
    {
        var animatorGraffiti = GraffitiUI.GetComponentInParent<Animator>();
        var animatorGentleman = Gentleman.GetComponentInParent<Animator>();

        if (Graffiti.activeSelf) 
        {
            Erase.SetActive(true);
            animatorGraffiti.SetBool("Out", true);
            yield return new WaitForSeconds(15f);
            Erase.SetActive(false);
            Pop.SetActive(true);
            animatorGentleman.SetBool("In", true);
            yield return new WaitForSeconds(25f);
            Pop.SetActive(false);
        }
        else
        {
            Rip.SetActive(true);
            animatorGentleman.SetBool("Out", true);
            Rip.SetActive(false);
            Draw.SetActive(true);
            yield return new WaitForSeconds(15f);
            animatorGraffiti.SetBool("In", true);
            yield return new WaitForSeconds(25f);
            Draw.SetActive(false);
        }
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
