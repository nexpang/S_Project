using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftUnit : MonoBehaviour
{
    [SerializeField]
    protected float speed = 0.025f;
    [SerializeField]
    protected int hp = 4;
    [SerializeField]
    protected float attackDistance = 5f;

    [Header("공격받음 관련")]
    [SerializeField]
    protected float force = 1f;
    [SerializeField]
    protected float damageDelay = 0.5f;

    protected bool isDamaged = false;
    protected bool isAttack = false;
    protected bool isDead = false;

    protected Animator animator = null;

    protected Rigidbody2D rigid = null;

    // Start is called before the first frame update
    protected virtual void Start()
    {
        rigid = gameObject.GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    protected virtual void Update()
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
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "RightAttack")
        {
            if(hp <= 0)
            {
                Destroy(gameObject);
            }
            else
            {
                hp--;
            }
        }
    }
    protected virtual void Move()
    {
        transform.Translate(Vector2.right * speed);
    }
    protected virtual IEnumerator Damaged()
    {
        isDamaged = true;
        //rigid.AddForce(Vector2.right*left, ForceMode2D.Impulse);
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
