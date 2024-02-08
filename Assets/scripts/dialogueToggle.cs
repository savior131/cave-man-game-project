using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dialogueToggle : MonoBehaviour
{
    [SerializeField] GameObject handler;
    [SerializeField] GameObject button;
    public static bool dialogueFinished=false;
    public void enable()
    {
        if (dialogueFinished) return;
        handler.SetActive(true);
        button.SetActive(false);
        dialogueFinished = true;
    }
}
