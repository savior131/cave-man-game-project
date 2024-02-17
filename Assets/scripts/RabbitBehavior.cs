using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RabbitBehavior : MonoBehaviour
{
    [SerializeField] float speed;
    Vector3 dir;
    [SerializeField] float rotationSpeed;
    [SerializeField] Transform rabbit;
    [SerializeField] CharacterController characterController;
    [SerializeField] float gravity = -9.82f;
    float velocity;
    [SerializeField] float gravityMultiplaier = 3.0f;
    float dirX;
    float dirZ;
    
    private void Start()
    {
        StartCoroutine(randomDirDelay());
        
    }
    private void Update()
    {
        handleGravity();
        handleMovment();
    }
    void handleMovment()
    {
        dir = new Vector3(dirX, dir.y, dirZ);
        dir.Normalize();
        characterController.Move(dir * speed * Time.deltaTime);
        if (new Vector2(dir.x, dir.z).magnitude > 0)
        {
            rabbit.transform.rotation = Quaternion.Lerp(rabbit.transform.rotation, Quaternion.LookRotation(new Vector3(dir.x, 0, dir.z)), rotationSpeed * Time.deltaTime);
        }
    }
    void handleGravity()
    {
        if (characterController.isGrounded && velocity < 0.0f)
        {
            velocity = -1.0f;
        }
        else
        {
            velocity += gravity * gravityMultiplaier * Time.deltaTime;
        }
        dir.y = velocity;
    }

    IEnumerator randomDirDelay()
    {
        while (true)
        {
            dirZ = Random.Range(-1f, 1f);
            dirX = Random.Range(-1f, 1f);
            yield return new WaitForSeconds(5f);
            dirZ = 0;
            dirX = 0;
            yield return new WaitForSeconds(3f);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        dirZ = -dirZ;
    }
    private void OnCollisionStay(Collision collision)
    {
        dirZ = -dirZ;
    }
}
