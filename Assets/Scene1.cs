using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

public class Scene1 : MonoBehaviourPunCallbacks
{
    private void Start()
    {
        PhotonNetwork.NickName = "Player";
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        // �����_���ȃ��[���ɎQ������
        PhotonNetwork.JoinRandomRoom();
    }

    // �����_���ŎQ���ł��郋�[�������݂��Ȃ��Ȃ�A�V�K�Ń��[�����쐬����
    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        // ���[���̎Q���l����2�l�ɐݒ肷��
        var roomOptions = new RoomOptions();
        roomOptions.MaxPlayers = 2;

        PhotonNetwork.CreateRoom(null, roomOptions);
    }

 /*   public override void OnJoinedRoom()
    {
        var position = new Vector3(Random.Range(-3f, 3f), Random.Range(-3f, 3f));
        PhotonNetwork.Instantiate("Avatar", position, Quaternion.identity);

        if (PhotonNetwork.IsMasterClient)
        {
            PhotonNetwork.CurrentRoom.SetStartTime(PhotonNetwork.ServerTimestamp);
        }
    }*/
}