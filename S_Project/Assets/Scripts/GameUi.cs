using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameUi : MonoBehaviour
{
    [SerializeField]
    GameObject ozing = null;
    [SerializeField]
    Transform spawnPoint = null;
    public void SpawnOzing()
    {
        Instantiate(ozing, spawnPoint.position, Quaternion.identity);
    }
}
