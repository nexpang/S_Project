using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    [SerializeField]
    private Button costButton = null;
    [SerializeField]
    private Text textCost = null;
    private float cost = 0;
    private float c = 0;
    private float plusCost = 1;
    private float costUpgrade = 0;
    [SerializeField]
    private Text textCostUpgrade = null;
    [SerializeField]
    private Text textLevel = null;
    private float upgradeCost = 50;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("AutoCostUp");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private IEnumerator AutoCostUp()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.1f);
            switch (costUpgrade)
            {
                case 0:
                    plusCost = 1;
                    upgradeCost = 50;
                    textLevel.text = "Level 1";
                    break;
                case 1:
                    plusCost = 1.5f;
                    upgradeCost = 100;
                    textLevel.text = "Level 2";
                    break;
                case 2:
                    plusCost = 2f;
                    upgradeCost = 150;
                    textLevel.text = "Level 3";
                    break;
                case 3:
                    plusCost = 3f;
                    upgradeCost = 200;
                    textLevel.text = "Level 4";
                    break;
                case 4:
                    plusCost = 4.5f;
                    upgradeCost = 250;
                    textLevel.text = "Level 5";
                    break;
                case 5:
                    plusCost = 6f;
                    textLevel.text = "MaxLevel";
                    costButton.interactable = false;
                    break;
                default:
                    break;
            }
            c = float.Parse(textCost.text);
            cost = c;
            cost += plusCost;
            textCost.text = string.Format("{0:F0}", cost);
            textCostUpgrade.text = upgradeCost.ToString();
        }
    }
    public void CostUpgrade()
    {
        if (cost < upgradeCost)
            return;
        cost -= upgradeCost;
        textCost.text = string.Format("{0:F0}", cost);
        costUpgrade++;
    }
}
