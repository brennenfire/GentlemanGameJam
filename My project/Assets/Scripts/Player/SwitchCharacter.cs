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
        Gentleman.SetActive(true);
        Graffiti.SetActive(true);
        CheckOnStart();
    }

    void CheckOnStart()
    {
        Gentleman.SetActive(false);
        if (Graffiti.activeSelf)
        {
            SwitchObjects.Instance.Switch("Graffiti");
            GraffitiUI.SetActive(true);
            GentlemanUI.SetActive(false);
        }
        else
        {
            SwitchObjects.Instance.Switch("Gentleman");
            GraffitiUI.SetActive(false);
            GentlemanUI.SetActive(true);
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
        yield return new WaitForSeconds(0.70f);
        canSwitch = true;
        Check();
    }

    IEnumerator PlayAnimations()
    {
        var animatorGraffiti = GraffitiUI.GetComponentInParent<Animator>();
        var animatorGentleman = GentlemanUI.GetComponentInParent<Animator>();

        if (Graffiti.activeSelf) 
        {
            GraffitiUI.SetActive(false);
            Erase.SetActive(true);
            animatorGraffiti.SetBool("Out", true);
            yield return new WaitForSeconds(0.25f);
            animatorGraffiti.SetBool("Out", false);
            Erase.SetActive(false);
            Pop.SetActive(true);
            animatorGentleman.SetBool("In", true);
            yield return new WaitForSeconds(0.45f);
            Pop.SetActive(false);
            animatorGentleman.SetBool("In", false);
            GentlemanUI.SetActive(true);
        }
        else
        {
            GentlemanUI.SetActive(false);
            Rip.SetActive(true);
            animatorGentleman.SetBool("Out", true);
            yield return new WaitForSeconds(0.25f);
            animatorGentleman.SetBool("Out", false);
            Rip.SetActive(false);
            Draw.SetActive(true);
            animatorGraffiti.SetBool("In", true);
            yield return new WaitForSeconds(0.45f);
            animatorGraffiti.SetBool("In", false);
            Draw.SetActive(false);
            GraffitiUI.SetActive(true);
        }
    }

    void Check()
    {
        if (Graffiti.activeSelf)
        {
            SwitchObjects.Instance.Switch("Gentleman");
            Gentleman.SetActive(true);
            Graffiti.SetActive(false);
        }
        else
        {
            SwitchObjects.Instance.Switch("Graffiti");
            Gentleman.SetActive(false);
            Graffiti.SetActive(true);
        }
    }
}
