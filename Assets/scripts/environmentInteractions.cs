using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnvironmentInteractions : MonoBehaviour
{
    public static Transform mean;
    [SerializeField] TextMeshProUGUI info;
    [SerializeField] float maxDistance;
    [SerializeField] LayerMask whatIsDecoration;
    [SerializeField] LayerMask whatIsTalkable;
    [SerializeField] LayerMask whatIsCollected;
    [SerializeField]GameObject speakButton;
    [SerializeField]GameObject collectButton;
    [SerializeField]GameObject guideTXT;
    [SerializeField] Transform hand;
    private Transform gameObjectTransform;
    private Collider col;
    bool foundDecoration;
    bool foundTalkable;
    bool foundCollectable;
    public static bool spearTaken=false;
    bool collectedTrees = false;
    GameObject collidedOBJ;
   [SerializeField] GameObject spearInHand;
    private void Awake()
    {
        mean = guideTXT.transform;
        gameObjectTransform = GetComponent<Transform>();
        col = GetComponent<Collider>();
        mean.position= Vector3.zero;
        mean.rotation= Quaternion.identity;
        mean.localScale= Vector3.one;
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
                collectedTrees = true;
                foundCollectable = true;
                collectButton.SetActive(true);
            }
            else if ((whatIsDecoration & (1 << cols[i].gameObject.layer)) != 0)
            {
                guideTXT.SetActive(true);
                if (Input.GetKeyDown(KeyCode.E))
                {
                    cols[i].gameObject.SetActive(false);
                  spearTaken = true;
                }
                foundDecoration = true;
                info.text = cols[i].gameObject.tag;
            }
            else if ((whatIsTalkable & (1 << cols[i].gameObject.layer)) != 0)
            {
                    mean.position = new Vector3(
                    (cols[i].gameObject.transform.position.x + transform.position.x) / 2,
                    (cols[i].gameObject.transform.position.y + transform.position.y) / 2,
                    (cols[i].gameObject.transform.position.z + transform.position.z) / 2);
                foundTalkable = true;
                speakButton.SetActive(true);
            }
           
            
          

            }
        if(!foundDecoration)
        {
            guideTXT.SetActive(false);
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
       if (spearTaken)
        {
            spearInHand.SetActive(true);
        }
        else
        {
            spearInHand.SetActive(false);

        }
        if (dialogueToggle.dialogueFinished)
        {
            Invoke("deactivator", 2.5f);
        }
    }
 void deactivator()
    {
       

       // dialogueToggle.dialogueFinished = false;

    }

    /*  private void OnDrawGizmos()
      {
        //  Gizmos.color = Color.yellow;
         // Gizmos.DrawWireSphere(col.bounds.center, maxDistance);
      }*/

}
