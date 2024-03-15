using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManger : MonoBehaviour
{
    public static MusicManger instance;
    [Header("Sad Music")]
    [SerializeField] AudioClip SadMusic;
    AudioSource audioSource;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
       
    }
    
    IEnumerator soundVolumeDown()
    {
        while (true)
        {
            audioSource.volume -= 0.01f* 5;
            if(audioSource.volume <= 0)
            {
                audioSource.clip = SadMusic;
                audioSource.Play();
                StartCoroutine(soundVolumeUp());
                yield break;
            }
                
            yield return new WaitForSeconds(0.2f);
        }
    }
    IEnumerator soundVolumeUp()
    {

        while (true)
        {
            audioSource.volume += 0.01f * 5;
            if (audioSource.volume >= 1)
                yield break;
            yield return new WaitForSeconds(0.2f);
        }
    }
    public void playSadMusic()
    {
        StartCoroutine(soundVolumeDown());
    }
}
