using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    [SerializeField]
    protected float speed = 0.025f;
    protected float distance = 100f;
    [SerializeField]
    protected float colliderdistance = 2f;

    protected int hp = 5;

    protected GameObject[] targets;

    protected Animator animator = null;


    protected bool isMoving = false;
    protected bool isAttack = false;
    protected bool isDead = false;

    protected virtual void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        if (hp <= 0)
        {
            isDead = true;
            gameObject.SetActive(false);
        }
        targets = FindObjectsOfType<GameObject>();
        foreach (GameObject target in targets)
        {
            if (gameObject.layer == 8)
            {
                if (target.layer == 9)
                {
                    distance = target.transform.localPosition.x - transform.localPosition.x;
                    if (distance <= colliderdistance)
                    {
                        isMoving = false;
                        if (isAttack || isDead)
                            return;
                        StartCoroutine("Attack");
                    }
                }
                else
                {
                    distance = 10000f;
                }
            }
            else if (gameObject.layer == 9)
            {
                if (target.layer == 8)
                {
                    distance = transform.localPosition.x - target.transform.localPosition.x;
                    if (distance <= colliderdistance)
                    {
                        isMoving = false;
                        if (isAttack || isDead)
                            return;
                        StartCoroutine("Attack");
                    }
                }
                else
                {
                    distance = 10000f;
                }
            }
        }
        if (distance > colliderdistance)
        {
            isMoving = true;
        }
        Move();
    }
    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Attack")
        {
            hp--;
        }
    }
    protected virtual void Move()
    {
        if (isMoving != true)
            return;
        if (gameObject.layer == 8)
            LeftUnitMove();
        if (gameObject.layer == 9)
            RightUnitMove();
    }
    protected virtual void LeftUnitMove()
    {
        transform.Translate(Vector2.right * speed);
    }
    protected virtual void RightUnitMove()
    {
        transform.Translate(Vector2.left * speed);
    }
    protected virtual IEnumerator Attack()
    {
        isAttack = true;
        transform.GetChild(0).gameObject.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        transform.GetChild(0).gameObject.SetActive(false);
        isAttack = false;
    }
}
