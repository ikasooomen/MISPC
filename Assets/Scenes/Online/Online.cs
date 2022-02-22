using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
}
