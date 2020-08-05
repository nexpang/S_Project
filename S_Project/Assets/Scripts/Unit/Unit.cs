using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    [SerializeField]
    protected float speed = 0.025f;
    [SerializeField]
    public int hp = 4;
    [SerializeField]
    protected float attackDistance = 5f;

    [Header("공격받음 관련")]
    [SerializeField]
    protected float force = 1f;
    [SerializeField]
    protected float damageDelay = 0.5f;

    protected bool isDamaged = false, isAttack = false, isDead = false;

    protected Animator animator = null;

    protected Rigidbody2D rigid = null;

    // Start is called before the first frame update
    protected virtual void Start()
    {
        rigid = gameObject.GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    protected virtual void FixedUpdate()
    {
        Debug.DrawRay(rigid.position, new Vector2(attackDistance, 0f), new Color(0, 1, 0));
        RaycastHit2D rayHit = Physics2D.Raycast(rigid.position, Vector2.right, attackDistance, LayerMask.GetMask("RightUnit"));
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
        if(gameObject.transform.position.x > GameManager.Instance.limitMaxX + 10f)
        {
            StartCoroutine("Despawn");
        }
    }
    //protected virtual void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.tag == "RightAttack")
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
    //    if (collision.tag == "LongRangeRightAttack")
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
    protected virtual void Move()
    {
        transform.Translate(Vector2.right * speed);
    }

    public void TakeDamage(int damage)
    {
        if (hp <= 0)
        {
            StartCoroutine("Despawn");
        }
        else
        {
            hp -= damage;
            StartCoroutine("Damaged");
        }
    }
    protected virtual IEnumerator Despawn()
    {
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }
    protected virtual IEnumerator Damaged()
    {
        int critical = Random.Range(0, 10);
        isDamaged = true;
        //rigid.AddForce(Vector2.right*left, ForceMode2D.Impulse);
        if (critical == 0)
            gameObject.transform.Translate(Vector2.left * 10 * force * Time.deltaTime);
        yield return new WaitForSeconds(damageDelay);
        isDamaged = false;
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
