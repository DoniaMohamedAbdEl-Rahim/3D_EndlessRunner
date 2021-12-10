using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuContoller : MonoBehaviour
{
    [SerializeField]
    GameObject settingWindow;
    bool isSettingOpened = false;
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void StartTheGame()
    {
        SceneManager.LoadScene(1);
    }
    public void ExitGame()
    {
        Application.Quit();
    }
    public void OpenSetting()
    {
        isSettingOpened = !isSettingOpened;
        settingWindow.gameObject.SetActive(isSettingOpened);
    }
}
