using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage1 : MonoBehaviour
{
    [SerializeField]
    private GameObject swordUnit = null;
    private GameObject swordObject = null;

    [SerializeField]
    private Transform spawnPosition = null;

    void Start()
    {
        StartCoroutine("SpawnSwordEnemy");
    }
    void Update()
    {
        
    }
    private IEnumerator SpawnSwordEnemy()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(3f, 5f));
            if (SwordPoolManager.Instance.transform.childCount > 0)
            {
                swordObject = SwordPoolManager.Instance.transform.GetChild(0).gameObject;
                swordObject.transform.SetParent(null);
                swordObject.SetActive(true);
            }
            else
            {
                swordObject = Instantiate(swordUnit, spawnPosition.position, Quaternion.identity);
            }
            swordObject.transform.localRotation = Quaternion.Euler(0, -180, 0);
            swordObject.transform.position = spawnPosition.position;
            swordObject.layer = 9;
        }
    }
}
