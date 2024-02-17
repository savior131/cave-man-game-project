using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float speed;
    Vector3 dir;
    [SerializeField] float rotationSpeed;
    [SerializeField] Transform character;
    [SerializeField] Animator anim;
    [SerializeField] CharacterController characterController;
    [SerializeField] float gravity = -9.82f;
    float velocity;
    [SerializeField] float gravityMultiplaier = 3.0f;
    PlayerHunt playerHunt;
    private void Start()
    {
        playerHunt = GetComponent<PlayerHunt>();
    }
    private void Update()
    {
       // if (DialogueSystem.inDialogue) return; 
        handleGravity();
        Debug.Log(playerHunt.Hunt);
        if (playerHunt.Hunt) {
            anim.SetFloat("speed", 0);
            return; 
        }
        handleMovment();
    }
    void handleMovment()
    {
        dir = new Vector3(Input.GetAxis("Horizontal"), dir.y, Input.GetAxis("Vertical"));
        dir.Normalize();
        dir = Quaternion.Euler(0, -45, 0) * dir;
        handleAnimation();
        characterController.Move(dir * speed * Time.deltaTime);
        playerLook();
    }

    private void handleAnimation()
    {
        anim.SetFloat("speed", new Vector2(dir.x, dir.z).magnitude);
    }

    private void playerLook()
    {
        if (new Vector2(dir.x, dir.z).magnitude > 0)
        {
            character.transform.rotation = Quaternion.Lerp(character.transform.rotation, Quaternion.LookRotation(new Vector3(dir.x, 0, dir.z)), rotationSpeed * Time.deltaTime);
        }
    }

    void handleGravity()
    {
        if(characterController.isGrounded && velocity < 0.0f)
        {
            velocity = -1.0f;
        }
        else
        {
            velocity += gravity * gravityMultiplaier * Time.deltaTime; 
        }
        dir.y = velocity;
    }
}
