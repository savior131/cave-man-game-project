using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rise : MonoBehaviour
{
    [SerializeField] GameObject objectToBerised;
    [SerializeField] GameObject text; 
    private void OnTriggerEnter(Collider other)
    {
        objectToBerised.SetActive(true);
        text.SetActive(true);
    }
}
