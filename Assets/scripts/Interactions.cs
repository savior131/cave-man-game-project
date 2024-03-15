using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactions : MonoBehaviour
{
    [SerializeField] Animator[] anim;
    bool canAttack=true;
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.E)&&canAttack&&EnvironmentInteractions.spearTaken)
        {
            StartCoroutine(f());

            anim[0].SetTrigger("attack");
            anim[1].SetTrigger("attack");

        }
    }
    IEnumerator f()
    {
        canAttack = false;
        yield return new WaitForSeconds(1f);
        canAttack = true;
    }
}
