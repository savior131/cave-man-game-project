using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootStepsSound : MonoBehaviour
{
    [SerializeField] AudioSource footStep;

    [SerializeField] AudioClip[] footStepGrass;
    [SerializeField] AudioClip[] footStepConcrete;
    [SerializeField] AudioClip[] footStepSand;
    [SerializeField] surface surfaceType;
    enum surface
    {
        Grass,
        Concrete,
        Sand
    }

    void PlayFootSteps()
    {
        AudioClip audioClip = null;
        switch(surfaceType)
        {
            case surface.Grass:
                audioClip = footStepGrass[Random.Range(0, footStepGrass.Length)];
                break;
            case surface.Concrete:
                audioClip = footStepConcrete[Random.Range(0, footStepGrass.Length)];
                break;
            case surface.Sand:
                audioClip = footStepSand[Random.Range(0, footStepGrass.Length)];
                break;
        }
        footStep.clip = audioClip;
        footStep.volume = Random.Range(0.12f, 0.15f);
        footStep.Play();
    }

    
}
