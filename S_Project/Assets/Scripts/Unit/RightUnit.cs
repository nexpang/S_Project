using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightUnit : MonoBehaviour
{
    [SerializeField]
    protected float speed = 0.025f;

    protected int hp = 3;

    protected bool isMoving = false;
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
        Debug.DrawRay(rigid.position, new Vector2(-2f, 0f), new Color(0, 1, 0));
        RaycastHit2D rayHit = Physics2D.Raycast(rigid.position, Vector2.left, 2f, LayerMask.GetMask("LeftUnit"));
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
        if (collision.tag == "LeftAttack")
        {
            if (hp <= 0)
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
