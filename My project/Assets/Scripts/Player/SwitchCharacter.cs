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
        yield return new WaitForSeconds(0.40f);
    }

    IEnumerator PlayAnimations()
    {
        var animatorGraffiti = GraffitiUI.GetComponentInParent<Animator>();
        var animatorGentleman = GentlemanUI.GetComponentInParent<Animator>();

        if (Graffiti.activeSelf) 
        {
            Erase.SetActive(true);
            animatorGraffiti.SetBool("Out", true);
            yield return new WaitForSeconds(0.15f);
            animatorGraffiti.SetBool("Out", false);
            Erase.SetActive(false);
            Pop.SetActive(true);
            animatorGentleman.SetBool("In", true);
            yield return new WaitForSeconds(0.25f);
            Pop.SetActive(false);
            animatorGentleman.SetBool("In", false);
        }
        else
        {
            Rip.SetActive(true);
            animatorGentleman.SetBool("Out", true);
            yield return new WaitForSeconds(0.15f);
            animatorGentleman.SetBool("Out", false);
            Rip.SetActive(false);
            Draw.SetActive(true);
            animatorGraffiti.SetBool("In", true);
            yield return new WaitForSeconds(0.25f);
            animatorGraffiti.SetBool("In", false);
            Draw.SetActive(false);
        }
        canSwitch = true;
        Check();
    }

    void Check()
    {
        if (Graffiti.activeSelf)
        {
            SwitchObjects.Instance.Switch("Gentleman");
            Gentleman.SetActive(true);
            GentlemanUI.SetActive(true);
            Graffiti.SetActive(false);
            GraffitiUI.SetActive(false);
        }
        else
        {
            SwitchObjects.Instance.Switch("Graffiti");
            Gentleman.SetActive(false);
            GentlemanUI.SetActive(false);
            Graffiti.SetActive(true);
            GraffitiUI.SetActive(true);
        }
    }
}
