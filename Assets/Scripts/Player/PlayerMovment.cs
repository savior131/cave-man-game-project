using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovment : MonoBehaviour
{
    PlayerInput playerInput;
    Vector3 movment;
    [SerializeField] Rigidbody rb;
    [SerializeField] float movmentSpeed;
    [SerializeField] float coefficient;
    [SerializeField] LayerMask ground;
    [SerializeField] AnimationCurve animcurve;
    [SerializeField] float groundSpeed;
    [SerializeField] float rotationSpeed;
    [SerializeField] float rotation;
    Quaternion rotaionRef;
    Vector3 counterMovment;
    Ray ray;
    RaycastHit hit;
    private void Awake()
    {
        playerInput = new PlayerInput();
    }

    private void OnEnable()
    {
        playerInput.Enable();
    }

    private void Update()
    {
        playerInputs();
        look();
    }
    private void FixedUpdate()
    {
        setPlayerMove();
        surfaceAligment();
    }

    void playerInputs()
    {
        movment = new Vector3(-playerInput.Movment.Move.ReadValue<Vector2>().y , 0 , playerInput.Movment.Move.ReadValue<Vector2>().x);
    }
    void setPlayerMove()
    {
        if(movment != Vector3.zero)
        {
            var matrix = Matrix4x4.Rotate(Quaternion.Euler(0, rotation, 0));
            var showedInput = matrix.MultiplyPoint3x4(movment);
            counterMovment = new Vector3(-rb.velocity.x, 0, -rb.velocity.z);
            rb.AddForce(showedInput * movmentSpeed);
            rb.AddForce(counterMovment * coefficient);
        }
    }

    void surfaceAligment()
    {
        ray = new Ray(transform.position, -transform.up);
        hit = new RaycastHit();
        rotaionRef = Quaternion.Euler(0, 0, 0);
        if(Physics.Raycast(ray ,out hit , ground))
        {
            rotaionRef = Quaternion.Lerp(transform.rotation ,
                Quaternion.FromToRotation(Vector3.up , hit.normal),animcurve.Evaluate(groundSpeed));
            transform.rotation = Quaternion.Euler(rotaionRef.eulerAngles.x, transform.eulerAngles.y, rotaionRef.eulerAngles.z);
        }
    }

    void look()
    {
        if (movment != Vector3.zero)
        {

            var matrix = Matrix4x4.Rotate(Quaternion.Euler(0, rotation, 0));
            var showedInput = matrix.MultiplyPoint3x4(movment);
            var relative = (transform.position + showedInput) - transform.position;
            var rot = Quaternion.LookRotation(relative, Vector3.up);

            transform.rotation = Quaternion.RotateTowards(transform.rotation , rot , rotationSpeed);
        }
    }
}
