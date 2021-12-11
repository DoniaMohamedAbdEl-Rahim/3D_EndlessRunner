using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
public class MainMenuContoller : MonoBehaviour
{
    [SerializeField]
    GameObject settingWindow;
    bool isSettingOpened = false;
    [SerializeField]
    TMP_InputField nameFeild;
    string playerName="";
    [SerializeField]
    StringSO name;
    void Start()
    {
        name.str = PlayerPrefs.GetString(playerName);
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
    public void SaveName()
    {
        PlayerPrefs.SetString(playerName,nameFeild.text);
        name.str = PlayerPrefs.GetString(playerName);
        OpenSetting();
    }
}
