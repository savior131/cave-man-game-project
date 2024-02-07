using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dialogueENable : MonoBehaviour
{
    [SerializeField] GameObject handler;
    [SerializeField] GameObject button;
    public void enable()
    {
        handler.SetActive(true);
        button.SetActive(false);
    }
}
