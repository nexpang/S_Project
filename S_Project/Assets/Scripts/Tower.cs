using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tower : MonoBehaviour
{
    public int towerHp = 10;

    [SerializeField]
    private GameObject gamoverUI = null;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void TakeDamage(int damage)
    {
        if (towerHp <= 0)
        {
            Time.timeScale = 0;
            gamoverUI.SetActive(true);
        }
        else
        {
            towerHp -= damage;
        }
    }
}
