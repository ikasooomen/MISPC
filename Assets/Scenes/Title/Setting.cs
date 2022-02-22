using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Setting : MonoBehaviour
{
    public GameObject settingPanel;
    public GameObject mainPanel;
    public GameObject subPanel1;
    public Text maintext;
    public Text subtext;
    [SerializeField] private Dropdown dropdown;//DropdownÇäiî[Ç∑ÇÈïœêî
    [SerializeField] private Camera Camera;
    [SerializeField] private Dropdown fovdropdown;
    [SerializeField] private Dropdown gamedropdown;

    // Start is called before the first frame update
    void Start()
    {
        Screen.SetResolution(1920, 1080, true, 60);

        if (!PlayerPrefs.HasKey("FOV")) PlayerPrefs.SetFloat("FOV", 2);
        if (!PlayerPrefs.HasKey("game")) PlayerPrefs.SetFloat("game", 0);

        if (PlayerPrefs.GetFloat("FOV") == 0)
        {
            Camera.fieldOfView = 90;
            fovdropdown.value = 0;
        }
        else if (PlayerPrefs.GetFloat("FOV") == 1)
        {
            Camera.fieldOfView = 110;
            fovdropdown.value = 1;
        }
        else if (PlayerPrefs.GetFloat("FOV") == 2)
        {
            Camera.fieldOfView = 103;
            fovdropdown.value = 2;
        }

        if (PlayerPrefs.GetFloat("game") == 0)
        {
            gamedropdown.value = 0;
        }
        else if (PlayerPrefs.GetFloat("game") == 1)
        {
            gamedropdown.value = 1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (settingPanel.activeSelf)
            {
                if (SceneManager.GetActiveScene().name != "TitleScene")
                { // TitleSceneÇ≈ÇÃÇ›Ç‚ÇËÇΩÇ¢èàóù
                    Time.timeScale = 1.0f;
                    Cursor.visible = false;
                    Cursor.lockState = CursorLockMode.Locked;
                }
                settingPanel.SetActive(false);
            }
            else
            {
                Time.timeScale = 0;
                settingPanel.SetActive(true);
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
            }

               
        }
    }

    public void Esc()
    {
        settingPanel.SetActive(true);

    }

    public void Endgame()
    {
        PlayerPrefs.SetFloat("gameEnd", 0);
        Application.Quit();
    }

    public void PointerEnter() 
    {
        maintext.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
        subtext.color = new Color(1.0f, 1.0f, 1.0f, 0.7f);
    }
    public void PointerExit()
    {
        maintext.color = new Color(1.0f, 1.0f, 1.0f, 0.7f);
        subtext.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
    }
    

    public void ChangePanelmain()
    {
        mainPanel.SetActive(true);
        subPanel1.SetActive(false);
    }
    public void ChangePanelsub()
    {
        mainPanel.SetActive(false);
        subPanel1.SetActive(true);
    }


    public void ScreenMode()
    {
        if (dropdown.value == 0)
        {
            Screen.SetResolution(1920, 1080, true, 60);
        }
        else if (dropdown.value == 1)
        {
            Screen.SetResolution(1920, 1080, false, 60); 
        }
    }

    public void TitleBack()
    {
        Time.timeScale = 1.0f;
        PlayerPrefs.SetFloat("gameEnd", 0);
        settingPanel.SetActive(false);
        SceneManager.LoadScene("TitleScene");
    }

    public void fov()
    {
        if (fovdropdown.value == 0)
        {
            Camera.fieldOfView = 90;
            PlayerPrefs.SetFloat("FOV", 0);
        }
        else if (fovdropdown.value == 1)
        {
            Camera.fieldOfView = 110;
            PlayerPrefs.SetFloat("FOV", 1);
        }
        else if (fovdropdown.value == 2)
        {
            Camera.fieldOfView = 103;
            PlayerPrefs.SetFloat("FOV", 2);
        }

    }

    public void game()
    {
        if (gamedropdown.value == 0)
        {
            PlayerPrefs.SetFloat("game", 0);
        }
        else if (gamedropdown.value == 1)
        {
            PlayerPrefs.SetFloat("game", 1);
        }

    }

}
