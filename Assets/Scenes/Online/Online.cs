using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Online : MonoBehaviourPunCallbacks
{
    public GameObject playercamera;
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
        }
        else
        {
            v = new Vector3(-300, 0, 0);
            r = new Vector3(0, 90, 0);
        }
        PhotonNetwork.Instantiate("player", v, Quaternion.identity);
        playercamera.transform.position = v;
        playercamera.transform.rotation = Quaternion.Euler(r);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
