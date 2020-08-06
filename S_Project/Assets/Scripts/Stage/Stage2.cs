using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    public bool gameOver = false;
    void Start()
    {
        StartCoroutine("Wait");

        FindObjectOfType<Tower>().stage = 1;
    }

    void Update()
    {
        //gameOver = FindObjectOfType<Tower>().gameOver;
    }
    private IEnumerator SpawnSwordEnemy()
    {
        while (gameOver == false)
        {
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
            swordObject.transform.localRotation = Quaternion.Euler(0, -180, 0);
            swordObject.transform.position = spawnPosition.position;
            swordObject.layer = 9;
            yield return new WaitForSeconds(Random.Range(4, 5));
        }
    }
    private IEnumerator SpawnWizardEnemy()
    {
        while (gameOver == false)
        {
            if (SwordPoolManager.Instance.transform.childCount > 0)
            {
                wizardObject = SwordPoolManager.Instance.transform.GetChild(0).gameObject;
                wizardObject.transform.SetParent(null);
                wizardObject.SetActive(true);
                wizardObject.GetComponent<BoxCollider2D>().enabled = true;
            }
            else
            {
                wizardObject = Instantiate(wizardUnit, spawnPosition.position, Quaternion.identity);
            }
            wizardObject.transform.localRotation = Quaternion.Euler(0, -180, 0);
            wizardObject.transform.position = spawnPosition.position;
            wizardObject.layer = 9;
            yield return new WaitForSeconds(Random.Range(5, 8));
        }
    }
    private IEnumerator Wait()
    {
        yield return new WaitForSeconds(3f);
        StartCoroutine("SpawnSwordEnemy");
        yield return new WaitForSeconds(2f);
        StartCoroutine("SpawnWizardEnemy");
    }
    public void LoadStage()
    {
        SceneManager.LoadScene("StageScene");
    }
    public void Stage2_Start()
    {
        SceneManager.LoadScene("Stage2");
    }
}
