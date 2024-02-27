﻿using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerHunt : MonoBehaviour
{
    [SerializeField] Transform Rabbit;
    [SerializeField] Transform character;
    [SerializeField] float rotationSpeed;
    [SerializeField] float maxDistance;
    [SerializeField] LayerMask whatIsHunted;
    [SerializeField] TextMeshProUGUI huntText;
    bool hunting=false;
    Vector3 dir;
    private Collider col;   
    [HideInInspector]public bool Hunt = false;


    private void Start()
    {
        col = GetComponent<Collider>();
    }
    private void Update()
    {
        Collider[] cols = Physics.OverlapSphere(col.bounds.center, maxDistance);
        for (int i = 0; i < cols.Length; i++)
        {
            if ((whatIsHunted & (1 << cols[i].gameObject.layer))!=0){
                hunting = true;
            }
        }
        if (hunting)
        {
            huntText.gameObject.SetActive(true);
            huntText.text = "اضغط";
            if (Input.GetKey(KeyCode.E))
            {
                playerLookToRabbit();
                handlePlayerHunt();
                Invoke("KillRabbit", 1.5f);
            }
        }
        else
        {
            huntText.text=string.Empty;
        }
       
     
       
    }
    void handlePlayerHunt()
    {
        character.transform.rotation = Quaternion.Lerp(character.transform.rotation, Quaternion.LookRotation(new Vector3(dir.x, 0, dir.z)), rotationSpeed * Time.deltaTime);
    }
    void playerLookToRabbit()
    {
        dir = Rabbit.transform.position - character.transform.position;
    }
    void KillRabbit()
    {
       Rabbit.gameObject.SetActive(false); 

    }
}