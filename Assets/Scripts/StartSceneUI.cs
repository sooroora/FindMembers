using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartSceneUI : MonoBehaviour
{
    [SerializeField] private GameObject settingUI;


    private void Start()
    {
        settingUI.SetActive(false);
    }

    public void MoveGameScene()
    {
        SceneManager.LoadScene("MainScene");
    }


    public void OpenSettingUI()
    {
        settingUI.SetActive(true);
    }

    public void CloseSettingUI()
    {
        settingUI.SetActive(false);
    }


    public void ExitGame()
    {
        Application.Quit();
    }
        
}
