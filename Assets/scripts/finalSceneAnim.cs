using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class finalSceneAnim : MonoBehaviour
{

    [SerializeField] int phase;
    [SerializeField] Animator anim;
   public void enableAnim()
    {
        switch(phase)
        {
            case 0:Debug.Log("phase 1 enabler"); anim.SetTrigger("phase1");gameObject.SetActive(false); break;
            case 1: Debug.Log("phase 2 enabler"); anim.SetTrigger("phase2"); gameObject.SetActive(false); ; break;
        }

    }
}
