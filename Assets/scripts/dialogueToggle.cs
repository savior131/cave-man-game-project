using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using System.Drawing;

public class dialogueToggle : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] CinemachineVirtualCamera cam;
    [SerializeField] GameObject[] handler;
    [SerializeField] GameObject button;
    [SerializeField] float size;
    float initSize;
    bool zoomIn;
    public static bool zoomOut;
    public static bool dialogueFinished=false;
    public static bool dialogueStarted=false;
    int i = 0;
    public void enable()
    {
        initSize = cam.m_Lens.OrthographicSize;
        cam.Follow = EnvironmentInteractions.mean;
        zoomIn = true;
        handler[i].SetActive(true);
        button.SetActive(false);
        dialogueFinished = true;
        dialogueStarted = true;
        i++;
    }
    private void Update()
    {
        if(zoomIn)
            SmoothZoomIn();
        if(zoomOut)
            SmoothZoomOut();
    }
    void SmoothZoomOut()
    {
        dialogueStarted = false;
        //dialogueFinished = false;
        zoomIn = false;
        cam.Follow=player;
        cam.m_Lens.OrthographicSize = Mathf.Lerp(cam.m_Lens.OrthographicSize, initSize, Time.deltaTime);
        if (initSize- cam.m_Lens.OrthographicSize < 0.1f)
            zoomOut = false;
    }
    void SmoothZoomIn()
    {
        cam.m_Lens.OrthographicSize = Mathf.Lerp(cam.m_Lens.OrthographicSize, size, Time.deltaTime);
        if (cam.m_Lens.OrthographicSize-size<0.1f)
             zoomIn = false;
    }
}
