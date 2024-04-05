using RTLTMPro;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class scenesMangement : MonoBehaviour
{
    Animator anim;
    [SerializeField] TMP_InputField input;
    [SerializeField] GameObject text;
    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    public void loadScene(int index)
    {
        StartCoroutine(delayScene(index));
    }

    IEnumerator delayScene(int index)
    {
        anim.SetTrigger("end");
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(index);
    }
}
