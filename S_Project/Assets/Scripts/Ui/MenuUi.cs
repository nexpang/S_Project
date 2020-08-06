using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuUi : MonoBehaviour
{
    public void StartButton()
    {
        SceneManager.LoadScene("StageScene");
    }
    public void GameExit()
    {
        Application.Quit();
    }
}
