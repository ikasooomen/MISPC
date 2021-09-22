using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    public void ChangeOnlineScene()
    {
        //SceneManager.LoadScene("MainScene");
    }

    public void ChangeCPUScene()
    {
        //SceneManager.LoadScene("MainScene");
    }

    public void ChangeTrainingScene()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
