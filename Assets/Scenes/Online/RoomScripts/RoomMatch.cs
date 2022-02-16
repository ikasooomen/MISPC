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
        // ロビーに参加するまでは、入力できないようにする
        canvasGroup.interactable = false;

        // ルームリスト表示を初期化する
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
        // ロビーに参加したら、入力できるようにする
        canvasGroup.interactable = true;
    }

    private void OnRoomNameInputFieldValueChanged(string value)
    {
        // ルーム名が1文字以上入力されている時のみ、ルーム作成ボタンを押せるようにする
        createRoomButton.interactable = (value.Length > 0);
    }

    private void OnCreateRoomButtonClick()
    {
        // ルーム作成処理中は、入力できないようにする
        canvasGroup.interactable = false;

        // 入力フィールドに入力したルーム名のルームを作成する
        var roomOptions = new RoomOptions();
        roomOptions.MaxPlayers = 2;
        PhotonNetwork.CreateRoom(roomNameInputField.text, roomOptions);
    }

    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        // ルームの作成が失敗したら、再び入力できるようにする
        roomNameInputField.text = string.Empty;
        canvasGroup.interactable = true;
    }

    public void OnJoiningRoom()
    {
        // ルーム参加処理中は、入力できないようにする
        canvasGroup.interactable = false;
    }

    public override void OnJoinedRoom()
    {
        // ルームへの参加が成功したら、UIを非表示にする
        Debug.Log("ルームに参加しました");
        int playerCount = PhotonNetwork.CurrentRoom.PlayerCount;
        if (playerCount != 2)
        {
            statusText.text = "対戦相手を待っています";
        }
        else
        {
            statusText.text = "対戦相手が揃いました";
        }
    }
    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        if (PhotonNetwork.IsMasterClient)
        {
            if (PhotonNetwork.CurrentRoom.PlayerCount == 2)
            {
                PhotonNetwork.CurrentRoom.IsOpen = false;
                statusText.text = "対戦相手が揃いました.";
                PhotonNetwork.IsMessageQueueRunning = false;
                PhotonNetwork.LoadLevel("OnlineScene");
            }
        }
    }

    public override void OnJoinRoomFailed(short returnCode, string message)
    {
        // ルームへの参加が失敗したら、再び入力できるようにする
        canvasGroup.interactable = true;
    }
}
