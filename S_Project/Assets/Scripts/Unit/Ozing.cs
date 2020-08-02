using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ozing : LeftUnit
{
    protected override IEnumerator Attack()
    {
        isAttack = true;
        animator.Play("Unit1_Attack");
        transform.GetChild(0).gameObject.SetActive(true);
        yield return new WaitForSeconds(0.3f);
        transform.GetChild(0).gameObject.SetActive(false);
        animator.Play("Unit1_Idle");
        yield return new WaitForSeconds(0.3f);
        isAttack = false;
    }

}
