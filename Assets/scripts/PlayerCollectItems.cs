using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerCollectItems : MonoBehaviour
{
    int applerCount , meatCount;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("collide");
        if (other.gameObject.CompareTag("Apple"))
        {
            Destroy(other.gameObject);
            applerCount++;
        }
        if (other.gameObject.CompareTag("Meat"))
        {
            Destroy(other.gameObject);
            meatCount++;
        }
    }
}
