using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class back : MonoBehaviour
{
    public void backToMain()
    {
        dialogueToggle.dialogueFinished = false;
        EnvironmentInteractions.spearTaken = false;
        SceneManager.LoadScene(0);
    }
}
