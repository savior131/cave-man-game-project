using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class SpearBeahvior : MonoBehaviour
{
    [SerializeField] GameObject throwPoint;
    [SerializeField] GameObject Rabbit;
    [SerializeField] float speed;
    [SerializeField] float rotationSpeed;
    float rot;
    Vector3 dir;
    private void Update()
    {
       // setRot();
    }
    void setRot()
    {
        dir = Rabbit.transform.position - transform.position;
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(new Vector3(dir.x, 0, dir.z)), rotationSpeed * Time.deltaTime);
    }
}
