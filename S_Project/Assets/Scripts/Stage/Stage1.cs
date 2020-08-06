using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Stage1 : MonoBehaviour
{
    [SerializeField]
    private GameObject swordUnit = null;
    private GameObject swordObject = null;

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
            yield return new WaitForSeconds(Random.Range(3f, 5f));
        }
    }
    private IEnumerator Wait()
    {
        yield return new WaitForSeconds(3f);
        StartCoroutine("SpawnSwordEnemy");
    }
    public void LoadStage()
    {
        SceneManager.LoadScene("StageScene");
    }
    public void Stage1_Start()
    {
        SceneManager.LoadScene("Stage1");
    }
}
