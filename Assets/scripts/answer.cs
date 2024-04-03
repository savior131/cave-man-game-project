using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;

public class answer : MonoBehaviour
{
    AudioManger aduio;
    MusicManger music;
    [SerializeField]GameObject otherSpeaker;

    private void Start()
    {
        aduio = GameObject.FindGameObjectWithTag("Audio Manger").GetComponent<AudioManger>();
        music = GameObject.FindGameObjectWithTag("Music Manger").GetComponent<MusicManger>();        
    }
   
    public void correctAnswer()
    {
        dialogueToggle.zoomOut = true;
        dialogueToggle.dialogueFinished=true;
        PlayerCollectItems.score += 50; 
        aduio.playCorrectAnswerSoundEffect();
        otherSpeaker.SetActive(false);
        gameObject.SetActive(false);
    }
    public void correctGoNext()
    {
        dialogueToggle.dialogueFinished = true;
        PlayerCollectItems.score += 50;
        aduio.playCorrectAnswerSoundEffect();
        StartCoroutine(delayNextScene());
        
    }
    public void correctSound()
    {
        aduio.playCorrectAnswerSoundEffect();
    }
    public void wrongAnswer()
    {
        CameraShake.instance.setCameraShake(4, 0.3f);
        PlayerCollectItems.score -= 50;
        aduio.playWrongAnswerSoundEffect();
        StartCoroutine(delaySceneRealode());
    }
    IEnumerator delaySceneRealode()
    {
        yield return new WaitForSeconds(1f);
        dialogueToggle.dialogueFinished = false;
        SceneManager.LoadScene(0);
    }
    IEnumerator delayNextScene()
    {
        yield return new WaitForSeconds(1f);
       // dialogueToggle.dialogueFinished = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }
}
