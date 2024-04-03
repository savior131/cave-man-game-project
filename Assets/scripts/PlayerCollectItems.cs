using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class PlayerCollectItems : MonoBehaviour
{
    public static int appleCount , meatCount;
    public static int score = 0;
    
    [SerializeField] GameObject dialogue;
    [SerializeField] TextMeshProUGUI appleText, meatText, ScoreText;
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("collide");
        if (other.gameObject.CompareTag("Apple"))
        {
            Destroy(other.gameObject);
            appleCount++;
        }
        if (other.gameObject.CompareTag("Meat"))
        {
            Destroy(other.gameObject);
            meatCount++;
        }
    }
    private void Update()
    {
        if (score < 0)
        {
            score = 0;
        }
        ScoreText.SetText(score.ToString());
        appleText.text = appleCount.ToString();
        meatText.text = meatCount.ToString();

        if (GameObject.FindGameObjectWithTag("Apple")==null)
        {
            dialogue.SetActive(true);
        }
    }
}
