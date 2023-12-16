using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraffitiPower : MonoBehaviour
{
    [SerializeField] GameObject Graffiti;
    [SerializeField] int uses = 1;

    List<GameObject> graffitis = new List<GameObject>();
    bool canPlace = true;

    public int Uses => uses;

    public List<GameObject> Graffitis => graffitis;
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
        if (canPlace)
        {
            if (graffitis.Count >= uses)
            {
                StartCoroutine(FadeOut());
            }
            StartCoroutine(ResetPlacement());
            var test = Instantiate(Graffiti, transform.position + new Vector3(0f, 0f, 0f), Quaternion.identity);
            graffitis.Add(test);
        }
    }

    IEnumerator ResetPlacement()
    {
        canPlace = false;
        yield return new WaitForSeconds(0.8f);
        canPlace = true;
    }

    IEnumerator FadeOut()
    {
        yield return new WaitForSeconds(0.1f);
        graffitis[0].GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0.8f);
        yield return new WaitForSeconds(0.1f);
        graffitis[0].GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0.6f);
        yield return new WaitForSeconds(0.1f);
        graffitis[0].GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0.4f);
        yield return new WaitForSeconds(0.1f);
        graffitis[0].GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0.2f);
        yield return new WaitForSeconds(0.1f);
        Destroy(graffitis[0]);
        graffitis.RemoveAt(0);
    }

    public void RemoveFromList(GameObject target)
    {
        Destroy(target);
        graffitis.Remove(target);
    }
}
