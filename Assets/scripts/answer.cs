using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;

public class answer : MonoBehaviour
{
   
    public void correctAnswer()
    {
        gameObject.SetActive(false);
    }
    public void wrongAnswer()
    {
        dialogueToggle.dialogueFinished = false;
        SceneManager.LoadScene(0);

    }
}
