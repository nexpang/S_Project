using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameUi : MonoBehaviour
{
    [SerializeField]
    private GameObject moono = null;
    [SerializeField]
    private GameObject swordUnit = null;
    private GameObject swordObject = null;
    [SerializeField]
    private GameObject wizardUnit = null;
    private GameObject wizardObject = null;
    [SerializeField]
    private Transform spawnPosition = null;
    public void SpawnOzing()
    {
        Instantiate(moono, spawnPosition.position, Quaternion.identity);
    }
    public void SpawnUnit_Sword()
    {
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
        swordObject.transform.position = spawnPosition.position;
    }
    public void SpawnUnit_Wizard()
    {
        if (WizardPoolManager.Instance.transform.childCount > 0)
        {
            wizardObject = WizardPoolManager.Instance.transform.GetChild(0).gameObject;
            wizardObject.transform.SetParent(null);
            wizardObject.SetActive(true);
        }
        else
        {
            wizardObject = Instantiate(wizardUnit, spawnPosition.position, Quaternion.identity);
        }
        wizardObject.transform.position = spawnPosition.position;
    }
}
