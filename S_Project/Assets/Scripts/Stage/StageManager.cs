using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StageManager : MonoBehaviour
{
    public bool stage1Clear = false;
    public bool stage2Clear = false;
    public bool stage3Clear = false;

    [SerializeField]
    private Button stage2 = null;
    [SerializeField]
    private Button stage3 = null;
    [SerializeField]
    private Button stage4 = null;
    void Start()
    {
        stage1Clear = Static.stage1Clear;
        stage2Clear = Static.stage2Clear;
        stage3Clear = Static.stage3Clear;
    }

    // Update is called once per frame
    void Update()
    {
        if (stage1Clear)
            stage2.interactable = true;
        if (stage2Clear)
            stage3.interactable = true;
        if (stage3Clear)
            stage4.interactable = true;
    }
    public void LoadStage()
    {
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
