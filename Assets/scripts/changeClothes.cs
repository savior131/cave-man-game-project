using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeClothes : MonoBehaviour
{
    [Header("old Lo0k")]
    [SerializeField] GameObject hair;
    [SerializeField] GameObject clothing;
    [SerializeField]GameObject spear;
    [Header("new look")]
    [SerializeField] GameObject clothing1;
    [SerializeField] GameObject necklace;
    public void change()
    {
        hair.SetActive(false);  
        clothing.SetActive(false);
        spear.SetActive(false);
        EnvironmentInteractions.spearTaken=false;
        necklace.SetActive(true);
        clothing1.SetActive(true);

    }

}
