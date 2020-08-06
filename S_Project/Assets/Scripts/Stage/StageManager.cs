using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageManager : MonoBehaviour
{
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void LoadStage()
    {
        if (Time.timeScale == 0)
            Time.timeScale = 1;
        SceneManager.LoadScene("StageScene");
    }
    public void Stage1_Start()
    {
        SceneManager.LoadScene("Stage1");
    }
    public void Stage2_Start()
    {
        SceneManager.LoadScene("Stage2");
    }
    public void Stage3_Start()
    {
        SceneManager.LoadScene("Stage3");
    }
}
