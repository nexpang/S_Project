using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit_Sword : LeftUnit
{
    [SerializeField]
    private float attackDelay = 0f;
    protected override IEnumerator Attack()
    {
        isAttack = true;
        animator.Play("Unit_Sword_Attack");
        transform.GetChild(0).gameObject.SetActive(true);
        yield return new WaitForSeconds(0.3f);
        transform.GetChild(0).gameObject.SetActive(false);
        animator.Play("Unit_Sword_Idle");
        yield return new WaitForSeconds(attackDelay);
        isAttack = false;
    }
}
