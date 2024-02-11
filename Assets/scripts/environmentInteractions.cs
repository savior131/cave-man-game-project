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
    [SerializeField] LayerMask whatIsCollected;
    [SerializeField]GameObject speakButton;
    [SerializeField]GameObject collectButton;
    private Transform gameObjectTransform;
    private Collider col;
   
    bool foundDecoration;
    bool foundTalkable;
    bool foundCollectable;

    private void Awake()
    {
        gameObjectTransform = GetComponent<Transform>();
        col = GetComponent<Collider>();
    }

    void Update()
    {
        Collider[] cols = Physics.OverlapSphere(col.bounds.center, maxDistance);
        foundDecoration = false;
        foundTalkable=false;
        foundCollectable=false;
        for (int i=0;i<cols.Length;i++)
            {
            if ((whatIsCollected & (1 << cols[i].gameObject.layer)) != 0&&dialogueToggle.dialogueFinished)
            {
                foundCollectable = true;
                collectButton.SetActive(true);
            }
            else if ((whatIsDecoration & (1 << cols[i].gameObject.layer)) != 0)
            {
               foundDecoration = true;
                info.text = cols[i].gameObject.tag;
            }
            else if ((whatIsTalkable & (1 << cols[i].gameObject.layer)) != 0&&!dialogueToggle.dialogueFinished)
            {
                foundTalkable = true;
                speakButton.SetActive(true);
            }
          

            }
        if(!foundDecoration)
        {
            info.text=string.Empty; 
        }
        if (!foundTalkable)
        {
            speakButton.SetActive(false);
        }
        if(!foundCollectable)
        {
            collectButton.SetActive(false);
        }

    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(col.bounds.center, maxDistance);
    }

}
