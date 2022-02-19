using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.UI;

public class RoomListViewElement : MonoBehaviour
{
    [SerializeField]
    private Text nameLabel = default;
    [SerializeField]
    private Text playerCounter = default;

    private RoomMatch matchmakingView;
    private Button button;

    public void Init(RoomMatch parentView)
    {
        matchmakingView = parentView;

        button = GetComponent<Button>();
        button.onClick.AddListener(OnButtonClick);
    }

    private void OnButtonClick()
    {
        // ���[���Q���������́A���͂ł��Ȃ��悤�ɂ���
        matchmakingView.OnJoiningRoom();

        // �{�^���ɑΉ��������[�����̃��[���ɎQ������
        PhotonNetwork.JoinRoom(nameLabel.text);


    }

    public void Show(RoomInfo roomInfo)
    {
        nameLabel.text = roomInfo.Name;
        playerCounter.text = string.Format("{0} / {1}", roomInfo.PlayerCount, roomInfo.MaxPlayers);

        // ���[���������łȂ����̂݁A�Q���{�^����������悤�ɂ���
        button.interactable = (roomInfo.PlayerCount < roomInfo.MaxPlayers);

        gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }
}