using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManger : MonoBehaviour
{
    [Header("Correct Answer")]
    [SerializeField] AudioClip correctAnswer;
    [SerializeField][Range(0, 1)] float volume = 1.0f;
    [Header("Wrong Answer")]
    [SerializeField] AudioClip wrongAnswer;
    [SerializeField][Range(0, 1)] float volume1 = 1.0f;

    private void Awake()
    {
        mangeSelgalton();
    }
    void mangeSelgalton()
    {
        int instant = FindObjectsOfType(GetType()).Length;
        if (instant > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    public void playCorrectAnswerSoundEffect()
    {
        AudioSource.PlayClipAtPoint(correctAnswer,Camera.main.transform.position, volume);
    }
    public void playWrongAnswerSoundEffect()
    {
        AudioSource.PlayClipAtPoint(wrongAnswer, Camera.main.transform.position, volume1);
    }

}
