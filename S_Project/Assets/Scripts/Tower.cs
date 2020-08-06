using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tower : MonoBehaviour
{
    public int towerHp = 500;
    [SerializeField]
    private GameObject gamoverUI = null;

    public int stage = 0;

    private Animator animator = null;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void TakeDamage(int damage)
    {
        if (towerHp <= 0)
        {
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
            StartCoroutine("Dead");
        }
        else
        {
            towerHp -= damage;
        }
    }
    private IEnumerator Dead()
    {
        if (gameObject.tag == "RightTower")
        {
            if (stage == 1)
                Static.stage1Clear = true;
            else if (stage == 2)
                Static.stage2Clear = true;
            else if (stage == 3)
                Static.stage3Clear = true;
        }
        if (stage == 1)
            FindObjectOfType<Stage1>().gameOver = true;
        else if (stage == 2)
            FindObjectOfType<Stage2>().gameOver = true;
        else if (stage == 3)
            //FindObjectOfType<Stage3>().gameOver = true;

        yield return new WaitForSeconds(0.5f);
        gameObject.SetActive(false);
        gamoverUI.SetActive(true);
    }
}
