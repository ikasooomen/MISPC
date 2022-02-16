using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    public GameObject CreateRoomPanel;

    public void ChangeCPUScene()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void ChangeTrainingScene()
    {
        SceneManager.LoadScene("TrainingScene");
    }

    public void OnClick_OpenRoomPanelButton()
    {
        //部屋作成ウインドウが表示していれば
        if (CreateRoomPanel.activeSelf)
        {
            //部屋作成ウインドウを非表示に
            CreateRoomPanel.SetActive(false);
        }
        else //そうでなければ
        {
            //部屋作成ウインドウを表示
            CreateRoomPanel.SetActive(true);
        }
    }
}
