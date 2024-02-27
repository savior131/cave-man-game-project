using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class scenesMangement : MonoBehaviour
{
    Animator anim;

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
