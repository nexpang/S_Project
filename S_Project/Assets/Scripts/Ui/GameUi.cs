using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUi : MonoBehaviour
{
    [SerializeField]
    private GameObject swordUnit = null;
    private GameObject swordObject = null;
    [SerializeField]
    private Button swordButton = null;
    [SerializeField]
    private float swordDelay = 0f;
    [SerializeField]
    private int swordCost = 100;

    [SerializeField]
    private GameObject wizardUnit = null;
    private GameObject wizardObject = null;
    [SerializeField]
    private Button wizardButton = null;
    [SerializeField]
    private float wizardDelay = 0f;
    [SerializeField]
    private int wizardCost = 100;

    [SerializeField]
    private GameObject lightsprit = null;
    private GameObject lightspritobject = null;
    [SerializeField]
    private Button lightspritButton = null;
    [SerializeField]
    private float lightspritDelay = 0f;               //lightsprit - 이제윤. 제외하곤 전부 경혁잏ㅎㅎㅎㅎ.........하..........
    [SerializeField]
    private int lightspritCost = 100;

    [SerializeField]
    private Transform spawnPosition = null;

    ColorBlock newColorBlock = ColorBlock.defaultColorBlock;

    [SerializeField]
    private Text textCost = null;
    private float c = 0;
    private float cost = 0;
    private void Start()
    {
        newColorBlock = swordButton.colors;
    }
    public void SpawnUnit_Sword()
    {
        c = float.Parse(textCost.text);
        cost = c;
        if (cost < swordCost)
            return;
        cost -= swordCost;
        textCost.text = string.Format("{0:F0}", cost);
        if (SwordPoolManager.Instance.transform.childCount > 0)
        {
            swordObject = SwordPoolManager.Instance.transform.GetChild(0).gameObject;
            swordObject.transform.SetParent(null);
            swordObject.SetActive(true);
            swordObject.GetComponent<BoxCollider2D>().enabled = true;
        }
        else
        {
            swordObject = Instantiate(swordUnit, spawnPosition.position, Quaternion.identity);
        }
        swordObject.transform.position = spawnPosition.position;
        swordObject.layer = 8;
        StartCoroutine("DelaySwordSpawn");
    }
    public void SpawnUnit_Wizard()
    {
        c = float.Parse(textCost.text);
        cost = c;
        if (cost < wizardCost)
            return;
        cost -= wizardCost;
        textCost.text = string.Format("{0:F0}", cost);
        if (WizardPoolManager.Instance.transform.childCount > 0)
        {
            wizardObject = WizardPoolManager.Instance.transform.GetChild(0).gameObject;
            wizardObject.transform.SetParent(null);
            wizardObject.SetActive(true);
            wizardObject.GetComponent<BoxCollider2D>().enabled = true;
        }
        else
        {
            wizardObject = Instantiate(wizardUnit, spawnPosition.position, Quaternion.identity);
        }
        wizardObject.transform.position = spawnPosition.position;
        wizardObject.layer = 8;
        StartCoroutine("DelayWizardSpawn");
    }
    public void SpawnUnit_LightSprit()
    {
        c = float.Parse(textCost.text);
        cost = c;
        if (cost < lightspritCost)
            return;
        cost -= lightspritCost;
        textCost.text = string.Format("{0:F0}", cost);
        if (LightSpritPoolManager.Instance.transform.childCount > 0)
        {
            lightspritobject = LightSpritPoolManager.Instance.transform.GetChild(0).gameObject;
            lightspritobject.transform.SetParent(null);
            lightspritobject.SetActive(true);
            lightspritobject.GetComponent<BoxCollider2D>().enabled = true;
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
        for (float i = 0f; i < 1;i += 0.1f/swordDelay)
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
