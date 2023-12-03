using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchCharacter : MonoBehaviour
{
    [SerializeField] GameObject Player1;
    [SerializeField] GameObject Player2;

    [ContextMenu("Switch")]
    public void Switch()
    {
        if (Player1.activeSelf)
        {
            Player2.SetActive(true);
            Player1.SetActive(false);
        }
        else
        {
            Player2.SetActive(false);
            Player1.SetActive(true);
        }
    }
}
