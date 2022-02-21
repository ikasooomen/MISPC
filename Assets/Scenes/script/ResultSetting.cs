using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ResultSetting : MonoBehaviour
{
    public GameObject settingPanel;
    public Text ScoreText;
    public Text TimeText;
    public Text HitRateText;

    string score;
    string time;
    string hitrate;

    void Start()
    {
        settingPanel.SetActive(false);
        PlayerPrefs.SetFloat("gameEnd", 0);
    }

    void Update()
    {
        if (PlayerPrefs.GetFloat("gameEnd") == 1)
        {
            Time.timeScale = 0;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;

            settingPanel.SetActive(true);

            ScoreText.text = score;
            TimeText.text = time+" •b";
            HitRateText.text = hitrate+" %";

        }
    }

    public void getScore(string x)
    {
        score = x;
    }

    public void getTime(string x)
    {
        time = x;
    }

    public void getHitRate(string x)
    {
        hitrate = x;
    }

    public void TitleBack()
    {
        Time.timeScale = 1.0f;
        settingPanel.SetActive(false);
        SceneManager.LoadScene("TitleScene");
        PlayerPrefs.SetFloat("gameEnd", 0);
    }

    public void Endgame()
    {
        Time.timeScale = 1.0f;
        PlayerPrefs.SetFloat("gameEnd", 0);
        Application.Quit();
    }

    public void ChangeCPUScene()
    {
        Time.timeScale = 1.0f;
        settingPanel.SetActive(false);
        SceneManager.LoadScene("SampleScene");
        PlayerPrefs.SetFloat("gameEnd", 0);
    }
}
