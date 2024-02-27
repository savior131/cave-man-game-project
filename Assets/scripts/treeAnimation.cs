using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class treeAnimation : MonoBehaviour
{
    Animator[] animator;
   // [SerializeField]Animator playerAnim;
    [SerializeField] CinemachineVirtualCamera cam;
    [SerializeField] float size;
    void Start()
    {
        animator = new Animator[gameObject.transform.childCount];
        for (int i = 0; i < gameObject.transform.childCount; i++)
        {
            animator[i] = gameObject.transform.GetChild(i).GetComponent<Animator>();
        }
        
    }
    public void enableAnime()
    {
        cam.m_Lens.OrthographicSize = size;
        for (int i = 0;i < animator.Length;i++) {
            animator[i].enabled = true;
        }
    }
    
}
