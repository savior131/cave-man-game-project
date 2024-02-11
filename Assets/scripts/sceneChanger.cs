using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneChanger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void backToCave (){
        dialogueToggle.dialogueFinished = false;
        DialogueSystem.inDialogue = false;
        SceneManager.LoadScene(0);

        }

   
}
