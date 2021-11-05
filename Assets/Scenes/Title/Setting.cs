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
    public Text text;
    [SerializeField] private Dropdown dropdown;//DropdownÇäiî[Ç∑ÇÈïœêî

    // Start is called before the first frame update
    void Start()
    {
        Screen.SetResolution(1920, 1080, true, 60);
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
                    Cursor.visible = false;
                }
                settingPanel.SetActive(false);
            }
            else
            {
                settingPanel.SetActive(true);
                Cursor.visible = true;
            }

               
        }
    }

    public void Esc()
    {
        settingPanel.SetActive(true);

    }

    public void Endgame()
    {
        Application.Quit();
    }

    public void PointerEnter()
    {
        text.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
    }
    public void PointerExit()
    {
        text.color = new Color(1.0f, 1.0f, 1.0f, 0.7f);
    }

    public void ChangePanel()
    {
        mainPanel.SetActive(true);
        subPanel1.SetActive(false);
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
        settingPanel.SetActive(false);
        SceneManager.LoadScene("TitleScene");
    }
}
