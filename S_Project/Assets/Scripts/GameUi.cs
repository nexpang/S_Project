using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameUi : MonoBehaviour
{
    [SerializeField]
    GameObject moono = null;
    [SerializeField]
    GameObject cube = null;
    [SerializeField]
    Transform spawnPoint = null;
    public void SpawnOzing()
    {
        Instantiate(moono, spawnPoint.position, Quaternion.identity);
    }
    public void SpawnCube()
    {
        Instantiate(cube, spawnPoint.position, Quaternion.identity);
    }
}
