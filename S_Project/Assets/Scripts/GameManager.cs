using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoSingleton<GameManager>
{
    [SerializeField]
    public float limitMinX = -75;
    [SerializeField]
    public float limitMaxX = 75;

    [SerializeField]
    private GameObject menuSet = null;
    // Start is called before the first frame update
    void Start()
    {
        
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
    public void TimeStop()
    {
        Time.timeScale = 0;
    }
    public void TimeStart()
    {
        Time.timeScale = 1;
    }

}
