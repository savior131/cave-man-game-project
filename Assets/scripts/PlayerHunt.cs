using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHunt : MonoBehaviour
{
    [SerializeField] Transform Rabbit;
    [SerializeField] Transform character;
    [SerializeField] float rotationSpeed;
    Vector3 dir;
    float hold =0;
    [HideInInspector]public bool Hunt = false;
    [SerializeField] GameObject spear;
    [SerializeField] float maxSpeed;
    [SerializeField] int maxHoldTime;
    Rigidbody rbSpear;
    private void Start()
    {
        rbSpear = spear.GetComponent<Rigidbody>();
    }
    private void Update()
    {
        
        if (Input.GetKey(KeyCode.E))
        {
            playerLookToRabbit();
            handlePlayerHunt();
            Hunt = true;
            hold += Time.deltaTime;
            
        }
        else
        {
            Hunt= false;
        }
        if (Input.GetKeyUp(KeyCode.E))
        {
            if(hold >= maxHoldTime)
            {
                rbSpear.velocity = new Vector3(rbSpear.velocity.x, rbSpear.velocity.y, maxSpeed);
            }
            else
            {
                rbSpear.velocity = new Vector3(rbSpear.velocity.x, rbSpear.velocity.y, maxSpeed * hold /maxHoldTime);
            }
            hold = 0;
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
    
}
