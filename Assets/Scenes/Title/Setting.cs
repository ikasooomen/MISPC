using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Setting : MonoBehaviour
{
    public GameObject settingPanel;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (settingPanel.activeSelf)
            {
                settingPanel.SetActive(false);
            }
            else
            {
                settingPanel.SetActive(true);
            }

               
        }
    }

    public void Endgame()
    {
        Application.Quit();
    }
}
