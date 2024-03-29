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
        CameraShake.instance.setCameraShake(3, 0.3f);
        StartCoroutine(delaySceneRealode());
    }
    IEnumerator delaySceneRealode()
    {
        yield return new WaitForSeconds(0.3f);
        dialogueToggle.dialogueFinished = false;
        DialogueSystem.inDialogue = false;
        SceneManager.LoadScene(0);
    }

   
}
