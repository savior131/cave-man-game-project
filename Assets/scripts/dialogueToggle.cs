using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dialogueToggle : MonoBehaviour
{
    [SerializeField] GameObject[] handler;
    [SerializeField] GameObject button;
    public static bool dialogueFinished=false;
    int i = 0;
    public void enable()
    {
      
        handler[i].SetActive(true);
        button.SetActive(false);
        dialogueFinished = true;
        i++;
    }
}
