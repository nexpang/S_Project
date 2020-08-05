using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUi : MonoBehaviour
{
    [SerializeField]
    private GameObject moono = null;

    [SerializeField]
    private GameObject swordUnit = null;
    private GameObject swordObject = null;
    [SerializeField]
    private Button swordButton = null;
    [SerializeField]
    private float swordDelay = 0f;

    [SerializeField]
    private GameObject wizardUnit = null;
    private GameObject wizardObject = null;
    [SerializeField]
    private Button wizardButton = null;
    [SerializeField]
    private float wizardDelay = 0f;

    [SerializeField]
    private GameObject lightsprit = null;
    private GameObject lightspritobject = null;
    [SerializeField]
    private Button lightspritButton = null;
    [SerializeField]
    private float lightspritDelay = 0f;               //lightsprit - 이제윤. 제외하곤 전부 경혁잏ㅎㅎㅎㅎ.........하..........

    [SerializeField]
    private Transform spawnPosition = null;

    ColorBlock newColorBlock = ColorBlock.defaultColorBlock;

    private void Start()
    {
        newColorBlock = swordButton.colors;
    }
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
        StartCoroutine("DelaySwordSpawn");
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
        StartCoroutine("DelayWizardSpawn");
    }
    public void SpawnUnit_LightSprit()
    {
        if (LightSpritPoolManager.Instance.transform.childCount > 0)
        {
            lightspritobject = LightSpritPoolManager.Instance.transform.GetChild(0).gameObject;
            lightspritobject.transform.SetParent(null);
            lightspritobject.SetActive(true);
        }
        else
        {
            lightspritobject = Instantiate(lightsprit, spawnPosition.position, Quaternion.identity);
        }
        lightspritobject.transform.position = spawnPosition.position;
        StartCoroutine("DelayLightSpritSpawn");
    }
    private IEnumerator DelaySwordSpawn()
    {
        swordButton.interactable = false;
        for (float i = 0f; i< swordDelay;i += 0.1f/swordDelay)
        {
            newColorBlock.disabledColor = new Color (i,i,i,1f);
            swordButton.colors = newColorBlock;
            yield return new WaitForSeconds(0.1f);
        }
        swordButton.interactable = true;
    }
    private IEnumerator DelayWizardSpawn()
    {
        wizardButton.interactable = false;
        for (float i = 0f; i < 1; i += 0.1f/wizardDelay)
        {
            newColorBlock.disabledColor = new Color(i, i, i, 1f);
            wizardButton.colors = newColorBlock;
            yield return new WaitForSeconds(0.1f);
        }
        wizardButton.interactable = true;
    }
    private IEnumerator DelayLightSpritSpawn()
    {
        lightspritButton.interactable = false;
        for (float i = 0f; i < 1; i += 0.1f / lightspritDelay)
        {
            newColorBlock.disabledColor = new Color(i, i, i, 1f);
            lightspritButton.colors = newColorBlock;
            yield return new WaitForSeconds(0.1f);
        }
        lightspritButton.interactable = true;
    }
}
