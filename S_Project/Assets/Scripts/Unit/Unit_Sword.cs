using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit_Sword : LeftUnit
{
    [SerializeField]
    private float attackDelay = 0f;
    [SerializeField]
    private Vector2 boxSize = Vector2.zero;
    [SerializeField]
    private int attackDamage = 1;
    protected override IEnumerator Attack()
    {
        isAttack = true;
        animator.Play("Unit_Sword_Attack");
        transform.GetChild(0).gameObject.SetActive(true);
        Collider2D[] collider2Ds = Physics2D.OverlapBoxAll(transform.GetChild(0).position, boxSize, 0);
        foreach(Collider2D collider in collider2Ds)
        {
            if(gameObject.layer == 8)
            {
                if (collider.gameObject.layer == 9)
                {
                    if (collider.tag == "Unit_Sword")
                    {
                        collider.GetComponent<Unit_Sword>().TakeDamage(attackDamage);
                    }
                    if (collider.tag == "Unit_Wizard")
                    {
                        collider.GetComponent<Unit_Wizard>().TakeDamage(attackDamage);
                    }
                    if (collider.tag == "LeftTower")
                    {
                        collider.GetComponent<Tower>().TakeDamage(attackDamage);
                    }
                    if (collider.tag == "RightTower")
                    {
                        collider.GetComponent<Tower>().TakeDamage(attackDamage);
                    }
                }
            }
            else
            {
                if (collider.gameObject.layer == 8)
                {
                    if (collider.tag == "Unit_Sword")
                    {
                        collider.GetComponent<Unit_Sword>().TakeDamage(attackDamage);
                    }
                    if (collider.tag == "Unit_Wizard")
                    {
                        collider.GetComponent<Unit_Wizard>().TakeDamage(attackDamage);
                    }
                    if (collider.tag == "LeftTower")
                    {
                        collider.GetComponent<Tower>().TakeDamage(attackDamage);
                    }
                    if (collider.tag == "RightTower")
                    {
                        collider.GetComponent<Tower>().TakeDamage(attackDamage);
                    }
                }
            }
        }
        yield return new WaitForSeconds(0.3f);
        transform.GetChild(0).gameObject.SetActive(false);
        animator.Play("Unit_Sword_Idle");
        yield return new WaitForSeconds(attackDelay);
        isAttack = false;
    }
    protected override IEnumerator Despawn()
    {
        GetComponent<BoxCollider2D>().enabled = false;
        yield return new WaitForSeconds(0.1f);
        gameObject.transform.SetParent(SwordPoolManager.Instance.transform);
        gameObject.SetActive(false);
    }
}