using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit_Wizard : LeftUnit
{
    [SerializeField]
    private GameObject leafball = null;
    private GameObject leafballObject = null;

    [SerializeField]
    private Transform attackPoint = null;

    [SerializeField]
    private float attackDelay = 0f;
    protected override IEnumerator Attack()
    {
        isAttack = true;
        animator.Play("Unit_Wizard_Attack");
        yield return new WaitForSeconds(0.3f);

        if (LeafballPoolManager.Instance.transform.childCount > 0)
        {
            leafballObject = LeafballPoolManager.Instance.transform.GetChild(0).gameObject;
            leafballObject.transform.SetParent(null);
            leafballObject.SetActive(true);
        }
        else
        {
            leafballObject = Instantiate(leafball, attackPoint.position, Quaternion.identity);
        }
        leafballObject.transform.position = attackPoint.position;

        animator.Play("Unit_Wizard_Idle");
        yield return new WaitForSeconds(attackDelay);
        isAttack = false;
    }
    protected override IEnumerator Despawn()
    {
        GetComponent<BoxCollider2D>().enabled = false;
        yield return new WaitForSeconds(0.1f);
        gameObject.transform.SetParent(WizardPoolManager.Instance.transform);
        gameObject.SetActive(false);
    }
}
