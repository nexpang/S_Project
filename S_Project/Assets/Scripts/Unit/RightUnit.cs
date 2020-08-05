using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RightUnit : Unit
{
    protected override void FixedUpdate()
    {
        Debug.DrawRay(rigid.position, new Vector2(-attackDistance, 0f), new Color(0, 1, 0));
        RaycastHit2D rayHit = Physics2D.Raycast(rigid.position, Vector2.left, attackDistance, LayerMask.GetMask("LeftUnit"));
        if (rayHit.collider == null)
        {
            Move();
        }
        else
        {
            if (isAttack || isDead)
                return;
            StartCoroutine("Attack");
        }
        if (gameObject.transform.position.x < GameManager.Instance.limitMinX - 10f)
        {
            StartCoroutine("Despawn");
        }
    }
    //protected override void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.tag == "LeftAttack")
    //    {
    //        if (hp <= 0)
    //        {
    //            StartCoroutine("Despawn");
    //        }
    //        else
    //        {
    //            hp--;
    //            StartCoroutine("Damaged");
    //        }
    //    }
    //    if (collision.tag == "LongRangeLeftAttack")
    //    {
    //        collision.gameObject.transform.SetParent(LeafballPoolManager.Instance.transform);
    //        collision.gameObject.SetActive(false);
    //        if (hp <= 0)
    //        {
    //            StartCoroutine("Despawn");
    //        }
    //        else
    //        {
    //            hp--;
    //            StartCoroutine("Damaged");
    //        }
    //    }
    //}
    protected override void Move()
    {
        transform.Translate(Vector2.left * speed);
    }
    protected override IEnumerator Damaged()
    {
        int critical = Random.Range(0, 10);
        isDamaged = true;
        if (critical == 0)
            gameObject.transform.Translate(Vector2.right * 10 * force * Time.deltaTime);
        yield return new WaitForSeconds(damageDelay);
        isDamaged = false;
    }
}
