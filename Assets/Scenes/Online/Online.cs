using ExitGames.Client.Photon;
using Photon.Pun;
using Photon.Realtime;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Online : MonoBehaviourPunCallbacks
{
    public GameObject playercamera;
    GameObject sho;

    // Start is called before the first frame update
    void Start()
    {
        PhotonNetwork.IsMessageQueueRunning = true;
        Debug.Log("ganbare");
        var v = new Vector3(300, 0, 0);
        var r = new Vector3(0, -90, 0);

        if (PhotonNetwork.IsMasterClient)
        {
            Debug.Log("自身がマスタークライアントです");
            PhotonNetwork.Instantiate("player", v, Quaternion.identity);
            sho = PhotonNetwork.Instantiate("shoot", v, Quaternion.Euler(0, -90, 0));
            sho.transform.parent = playercamera.transform;
        }
        else
        {
            v = new Vector3(-300, 0, 0);
            r = new Vector3(0, 90, 0);
            PhotonNetwork.Instantiate("player2", v, Quaternion.identity);
            sho = PhotonNetwork.Instantiate("shoot", v, Quaternion.Euler(0, 90, 0));
            sho.transform.parent = playercamera.transform;

        }
        playercamera.transform.position = v;
        playercamera.transform.rotation = Quaternion.Euler(r);

    }
    public override void OnDisconnected(DisconnectCause cause)
    {
        Debug.Log("OnDisconnected");
        Time.timeScale = 1.0f;
        PlayerPrefs.SetFloat("gameEnd", 0);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        SceneManager.LoadScene("TitleScene");
    }

    // 他のプレイヤーが退室した時
    /*public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        Debug.Log("OnPlayerLeftRoom");
        Time.timeScale = 1.0f;
        PlayerPrefs.SetFloat("gameEnd", 0);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        SceneManager.LoadScene("TitleScene");
    }*/

}
