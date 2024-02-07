using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnvironmentInteractions : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI info;
    [SerializeField] float maxDistance;
    [SerializeField] LayerMask whatIsDecoration;
    [SerializeField] LayerMask whatIsTalkable;
    private Transform gameObjectTransform;
    private Collider col;
    GameObject hitObject;
    Ray ray;
    RaycastHit hit;
    [SerializeField]GameObject speakButton;
   

    private void Awake()
    {
        gameObjectTransform = GetComponent<Transform>();
        col = GetComponent<Collider>();
    }

    void Update()
    {
        ray = new Ray(col.bounds.center, gameObjectTransform.forward);
        if (Physics.Raycast(ray, out hit, maxDistance, whatIsDecoration))
        {
            hitObject = hit.collider.gameObject;
            info.text = hitObject.tag;
        }
        else
        {
            info.text=string.Empty;
        }
        if (Physics.Raycast(ray, out hit, maxDistance, whatIsTalkable))
        {
         speakButton.SetActive(true);
        }
        else
        {
        speakButton.SetActive(false);  
       
        }
    }
  
    // Visualize the ray in the Scene view
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawRay(col.bounds.center, gameObjectTransform.forward * maxDistance);
    }
}
