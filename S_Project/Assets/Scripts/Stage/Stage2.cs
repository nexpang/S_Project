using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage2 : MonoBehaviour
{
    [SerializeField]
    private GameObject swordUnit = null;
    private GameObject swordObject = null;

    [SerializeField]
    private GameObject wizardUnit = null;
    private GameObject wizardObject = null;

    [SerializeField]
    private Transform spawnPosition = null;
    void Start()
    {
        StartCoroutine("SpawnSwordEnemy");
        StartCoroutine("SpawnWizardEnemy");
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
    private IEnumerator SpawnWizardEnemy()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(5f, 8f));
            if (SwordPoolManager.Instance.transform.childCount > 0)
            {
                wizardObject = SwordPoolManager.Instance.transform.GetChild(0).gameObject;
                wizardObject.transform.SetParent(null);
                wizardObject.SetActive(true);
            }
            else
            {
                wizardObject = Instantiate(wizardUnit, spawnPosition.position, Quaternion.identity);
            }
            wizardObject.transform.localRotation = Quaternion.Euler(0, -180, 0);
            wizardObject.transform.position = spawnPosition.position;
            wizardObject.layer = 9;
        }
    }
}
