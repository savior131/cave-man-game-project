using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class lastQuestions : MonoBehaviour
{
   [SerializeField] GameObject[] dialogues;
    int i = 0; 
    public void nextQuestions()
    {
     /*   if(i==dialogues.Length-1) {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }*/
        dialogues[i].SetActive(false);
        i++;
        dialogues[i].SetActive(true);
    }
}
