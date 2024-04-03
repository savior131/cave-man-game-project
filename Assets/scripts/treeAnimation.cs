using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class treeAnimation : MonoBehaviour
{
    [SerializeField] GameObject dialogue;
    Animator[] animator;
   // [SerializeField]Animator playerAnim;
    [SerializeField] CinemachineVirtualCamera cam;
    [SerializeField] float size;
    bool zoomOut;
    bool zoomIn;
    float initSize=0;
    void Start()
    {
        animator = new Animator[gameObject.transform.childCount];
        for (int i = 0; i < gameObject.transform.childCount; i++)
        {
            animator[i] = gameObject.transform.GetChild(i).GetComponent<Animator>();
        }
        
    }
    private void Update()
    {
        if(zoomOut)
            SmoothZoomOut();
        if(zoomIn)
            SmoothZoomIn();
    }
    public void enableAnime()
    {
        initSize = cam.m_Lens.OrthographicSize;
        dialogueToggle.dialogueFinished = false;
        zoomOut = true;
        StartCoroutine(omg());
        for (int i = 0;i < animator.Length;i++) {
            animator[i].enabled = true;
            
        }
        Invoke("dialogueActivator", 1.5f);
    }
    void dialogueActivator()
    {
       // dialogue.SetActive(true);
    }
    void SmoothZoomOut()
    {
        cam.m_Lens.OrthographicSize = Mathf.Lerp(cam.m_Lens.OrthographicSize,size,Time.deltaTime);
        if (size - cam.m_Lens.OrthographicSize < 0.1)
            zoomOut = false;
    }
    void SmoothZoomIn()
    {
        cam.m_Lens.OrthographicSize = Mathf.Lerp(cam.m_Lens.OrthographicSize, initSize, Time.deltaTime);
        if(cam.m_Lens.OrthographicSize-initSize<0.1)
            zoomIn = false;
    }
    IEnumerator omg()
    {
        yield return new WaitForSeconds(5);
        zoomIn = true;
    }
}
