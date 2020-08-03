using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameUi : MonoBehaviour
{
    [SerializeField]
    GameObject moono = null;
    [SerializeField]
    GameObject swordUnit = null;
    [SerializeField]
    Transform spawnPoint = null;
    public void SpawnOzing()
    {
        Instantiate(moono, spawnPoint.position, Quaternion.identity);
    }
    public void SpawnUnit_Sword()
    {
        Instantiate(swordUnit, spawnPoint.position, Quaternion.identity);
    }
}
