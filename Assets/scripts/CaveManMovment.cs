using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaveManMovment : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float rotationSpeed;
    Vector3 dir;
    Rigidbody rb;
    [SerializeField] Transform character;
    [SerializeField] Animator anim;
    float rot;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        handleMovment();
    }
    void handleMovment()
    {
        dir = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        dir.Normalize();
        dir = Quaternion.Euler(0, -45, 0) * dir;
        anim.SetFloat("speed", dir.magnitude);
        rb.velocity = new Vector3(dir.x, rb.velocity.y, dir.z);
        if (dir.magnitude > 0)
        {
            character.transform.rotation = Quaternion.Lerp(character.transform.rotation, Quaternion.LookRotation(dir) , rotationSpeed * Time.deltaTime);
        }
    }

}
