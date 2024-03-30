using System.Collections;
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
    [SerializeField] GameObject  huntText;
    [SerializeField] GameObject meat;
    bool hunting=false;
    Vector3 dir;
    private Collider col;   
    [HideInInspector]public bool Hunt = false;
    bool rabbitDeath = false;

    private void Start()
    {
        col = GetComponent<Collider>();
    }
    private void Update()
    {
        Collider[] cols = Physics.OverlapSphere(col.bounds.center, maxDistance);
        hunting=false ;
        for (int i = 0; i < cols.Length; i++)
        {
            if ((whatIsHunted & (1 << cols[i].gameObject.layer))!=0){
                hunting = true;

            }

        }
        if (hunting&EnvironmentInteractions.spearTaken)
        {
            Debug.Log("entered hunting");
            huntText.SetActive(true);
            if (Input.GetKeyUp(KeyCode.E) && !rabbitDeath)
            {
                playerLookToRabbit();
                handlePlayerHunt();
                Invoke("KillRabbit", 0.7f);
            }
        }
        else
        {
            huntText.SetActive(false);
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
        rabbitDeath = true;
        Rabbit.gameObject.GetComponentInChildren<Animator>().SetTrigger("Death");
        Rabbit.gameObject.GetComponent<RabbitBehavior>().enabled = false;
        Instantiate(meat, Rabbit.transform.position + new Vector3(0.5f , 0 , 0), Quaternion.identity);
        Instantiate(meat, Rabbit.transform.position, Quaternion.identity);
        Destroy(Rabbit.gameObject, 1f);
    }
}
