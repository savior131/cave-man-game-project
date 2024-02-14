using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;

public class answer : MonoBehaviour
{
    AudioManger aduio;
    MusicManger music;

    private void Awake()
    {
        aduio = GameObject.FindGameObjectWithTag("Audio Manger").GetComponent<AudioManger>();
        music = GameObject.FindGameObjectWithTag("Music Manger").GetComponent<MusicManger>();
    }
    public void correctAnswer()
    {
        gameObject.SetActive(false);
        aduio.playCorrectAnswerSoundEffect();
        music.playSadMusic();
    }
    public void wrongAnswer()
    {
        CameraShake.instance.setCameraShake(3, 0.3f);
        aduio.playWrongAnswerSoundEffect();
        StartCoroutine(delaySceneRealode());
    }
    IEnumerator delaySceneRealode()
    {
        yield return new WaitForSeconds(1f);
        dialogueToggle.dialogueFinished = false;
        SceneManager.LoadScene(0);
    }
}