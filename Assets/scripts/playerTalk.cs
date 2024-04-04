using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerTalk : MonoBehaviour
{
    Animator anim;
    bool startedTalking;
    // Start is called before the first frame update
    void Start()
    {
        anim=GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(dialogueToggle.dialogueStarted);
        if (dialogueToggle.dialogueStarted)
        {

            if(!startedTalking)
             StartCoroutine(animationScedule());
            GetComponent<PlayerController>().enabled = false;
            anim.SetLayerWeight(1, 1);
        }
        else
        {
         
            startedTalking = false;
            GetComponent<PlayerController>().enabled = enabled;
            anim.SetLayerWeight(1, 0);
        }

    }
    int i = 0;
    IEnumerator animationScedule()
    {
        startedTalking = true;
        i += 1;
        i%= 2;
        anim.SetTrigger($"talking ({i})");
        yield return new WaitForSeconds(3.2f);
        startedTalking = false;
    }
}
