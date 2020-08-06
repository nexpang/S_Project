using Packages.Rider.Editor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoSingleton<GameManager>
{
    [SerializeField]
    public float limitMinX = -75;
    [SerializeField]
    public float limitMaxX = 75;

    [SerializeField]
    private GameObject menuSet = null;

    [SerializeField]
    private Button costButton = null;
    [SerializeField]
    private Text textCost = null;
    private float cost = 0;
    private float c = 0;
    private float plusCost = 1;
    private float costUpgrade = 0;
    private float upgradeCost = 50;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("AutoCostUp");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            if (menuSet.activeSelf)
            {
                TimeStart();
                menuSet.SetActive(false);
            }
            else
            {
                TimeStop();
                menuSet.SetActive(true);
            }
        }
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
                    break;
                case 1:
                    plusCost = 1.5f;
                    upgradeCost = 100;
                    break;
                case 2:
                    plusCost = 2f;
                    upgradeCost = 150;
                    break;
                case 3:
                    plusCost = 3f;
                    upgradeCost = 200;
                    break;
                case 4:
                    plusCost = 4.5f;
                    upgradeCost = 250;
                    break;
                case 5:
                    plusCost = 6f;
                    costButton.interactable = false;
                    break;
                default:
                    break;
            }
            c = float.Parse(textCost.text);
            cost = c;
            cost += plusCost;
            textCost.text = string.Format("{0:F0}", cost);
        }
    }
    public void CostUpgrade()
    {
        if (cost < upgradeCost)
            return;
        cost -= upgradeCost;
        textCost.text = string.Format("{0:F0}", cost);
        costUpgrade ++;
    }
    public void TimeStop()
    {
        Time.timeScale = 0;
    }
    public void TimeStart()
    {
        Time.timeScale = 1;
    }
}
