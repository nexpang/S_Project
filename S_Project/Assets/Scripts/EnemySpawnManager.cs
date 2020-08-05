using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnManager : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }
    private IEnumerator SpawnSwordEnemy()
    {
        yield return new WaitForSeconds(1f);
    }
    private IEnumerator SpawnWizardEnemy()
    {
        yield return new WaitForSeconds(1f);
    }
}
