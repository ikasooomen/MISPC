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
        //�����쐬�E�C���h�E���\�����Ă����
        if (CreateRoomPanel.activeSelf)
        {
            //�����쐬�E�C���h�E���\����
            CreateRoomPanel.SetActive(false);
        }
        else //�����łȂ����
        {
            //�����쐬�E�C���h�E��\��
            CreateRoomPanel.SetActive(true);
        }
    }
}
