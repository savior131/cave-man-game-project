using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Windows;

public class nameEntryTransition : MonoBehaviour
{
    [SerializeField] TMP_InputField input;
    [SerializeField] GameObject text;
    public void nameENtered()
    {

        if (input.text.Length != 0)
        {
            StartCoroutine(delayScene(SceneManager.GetActiveScene().buildIndex + 1));
        }
        else
        {
            text.SetActive(true);
            Invoke("deactivateText", 2);
        }
    }
    private void deactivateText()
    {
        text.SetActive(false);
    }
    IEnumerator delayScene(int index)
    {
        PlayerCollectItems.score = 0;
        PlayerCollectItems.meatCount = 0;
        PlayerCollectItems.appleCount = 0;
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(index);
    }
}
