using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Leafball : MonoBehaviour
{
    [SerializeField]
    private float speed = 0f;
    [SerializeField]
    private int attackDamage = 1;

    void Start()
    {
        
    }

    void Update()
    {
        gameObject.transform.Translate(Vector3.right * speed * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (gameObject.transform.localRotation.y == 0)
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
                gameObject.transform.SetParent(LeafballPoolManager.Instance.transform);
                gameObject.SetActive(false);
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
                gameObject.transform.SetParent(LeafballPoolManager.Instance.transform);
                gameObject.SetActive(false);
            }
        }
    }
}
