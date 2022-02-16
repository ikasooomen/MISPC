using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.UI;

public class RoomMatch : MonoBehaviourPunCallbacks
{
    [SerializeField]
    private RoomListView roomListView = default;
    [SerializeField]
    private InputField roomNameInputField = default;
    [SerializeField]
    private Button createRoomButton = default;
    [SerializeField]
    private Text statusText;

    private CanvasGroup canvasGroup;

    private void Start()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        // ���r�[�ɎQ������܂ł́A���͂ł��Ȃ��悤�ɂ���
        canvasGroup.interactable = false;

        // ���[�����X�g�\��������������
        roomListView.Init(this);

        roomNameInputField.onValueChanged.AddListener(OnRoomNameInputFieldValueChanged);
        createRoomButton.onClick.AddListener(OnCreateRoomButtonClick);
    }

    private void Awake()
    {
        PhotonNetwork.AutomaticallySyncScene = true;
    }

    public override void OnJoinedLobby()
    {
        // ���r�[�ɎQ��������A���͂ł���悤�ɂ���
        canvasGroup.interactable = true;
    }

    private void OnRoomNameInputFieldValueChanged(string value)
    {
        // ���[������1�����ȏ���͂���Ă��鎞�̂݁A���[���쐬�{�^����������悤�ɂ���
        createRoomButton.interactable = (value.Length > 0);
    }

    private void OnCreateRoomButtonClick()
    {
        // ���[���쐬�������́A���͂ł��Ȃ��悤�ɂ���
        canvasGroup.interactable = false;

        // ���̓t�B�[���h�ɓ��͂������[�����̃��[�����쐬����
        var roomOptions = new RoomOptions();
        roomOptions.MaxPlayers = 2;
        PhotonNetwork.CreateRoom(roomNameInputField.text, roomOptions);
    }

    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        // ���[���̍쐬�����s������A�Ăѓ��͂ł���悤�ɂ���
        roomNameInputField.text = string.Empty;
        canvasGroup.interactable = true;
    }

    public void OnJoiningRoom()
    {
        // ���[���Q���������́A���͂ł��Ȃ��悤�ɂ���
        canvasGroup.interactable = false;
    }

    public override void OnJoinedRoom()
    {
        // ���[���ւ̎Q��������������AUI���\���ɂ���
        Debug.Log("���[���ɎQ�����܂���");
        int playerCount = PhotonNetwork.CurrentRoom.PlayerCount;
        if (playerCount != 2)
        {
            statusText.text = "�ΐ푊���҂��Ă��܂�";
        }
        else
        {
            statusText.text = "�ΐ푊�肪�����܂���";
        }
    }
    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        if (PhotonNetwork.IsMasterClient)
        {
            if (PhotonNetwork.CurrentRoom.PlayerCount == 2)
            {
                PhotonNetwork.CurrentRoom.IsOpen = false;
                statusText.text = "�ΐ푊�肪�����܂���.";
                PhotonNetwork.IsMessageQueueRunning = false;
                PhotonNetwork.LoadLevel("OnlineScene");
            }
        }
    }

    public override void OnJoinRoomFailed(short returnCode, string message)
    {
        // ���[���ւ̎Q�������s������A�Ăѓ��͂ł���悤�ɂ���
        canvasGroup.interactable = true;
    }
}
