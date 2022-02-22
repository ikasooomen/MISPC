using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EStatus : MonoBehaviourPunCallbacks, IPunObservable
{
    public delegate void OnHealthChangedDelegate();
    public OnHealthChangedDelegate onHealthChangedCallback;

    #region Sigleton
    private static EStatus instance;

    public static EStatus Instance
    {
        get
        {
            if (instance == null)
                instance = FindObjectOfType<EStatus>();
            return instance;
        }
    }
    #endregion

    [SerializeField]
    private float health;
    [SerializeField]
    private float maxHealth;
    [SerializeField]
    private float maxTotalHealth;

    public float Health
    {
        get
        {
            return health;
        }
        set
        {
            health = value;
        }
    }
    public float MaxHealth { get { return maxHealth; } }
    public float MaxTotalHealth { get { return maxTotalHealth; } }

    public void Heal(float health)
    {
        this.health += health;
        ClampHealth();
    }

    public void TakeDamage(float dmg)
    {
        if (!PhotonNetwork.IsMasterClient)
        {
            health -= dmg;
            ClampHealth();
            Debug.Log("EStatus");
        }
        else
        {
            ClampHealth();
            Debug.Log("!EStatus");
        }
    }

    public void AddHealth()
    {
        if (maxHealth < maxTotalHealth)
        {
            maxHealth += 1;
            health = maxHealth;

            if (onHealthChangedCallback != null)
                onHealthChangedCallback.Invoke();
        }
    }

    void ClampHealth()
    {
        health = Mathf.Clamp(health, 0, maxHealth);

        if (onHealthChangedCallback != null)
            onHealthChangedCallback.Invoke();
    }


    GameObject Text;
    public Text WL;
    int flag = 0;
    private void Start()
    {
        Text = GameObject.Find("WL");
        WL = Text.GetComponent<Text>();
        WL.text = "";
    }

    GameObject objGet;
    float totalTime = 3;
    int seconds;
    private void Update()
    {

        totalTime -= Time.deltaTime;
        seconds = (int)totalTime;

        if (seconds <= 0)
        {
            if (photonView.IsMine)
            {

                if (flag == 0)
                {
                    if (EStatus.Instance.Health == 0)
                    {
                        flag = 1;
                        WL.text = "LOSE";
                        StartCoroutine(Timer());
                    }
                    else if (Status.Instance.Health == 0)
                    {
                        flag = 1;
                        WL.text = "WIN";
                        StartCoroutine(Timer());
                    }
                }
            }
        }

        objGet = GameObject.Find("player(Clone)");

        if (objGet != null)
        {
            Health = Health;
            ClampHealth();
        }
    }

    IEnumerator Timer()
    {
        //3秒待つ
        yield return new WaitForSeconds(5.0f);
        PhotonNetwork.LeaveRoom();
        PhotonNetwork.LeaveLobby();
        PhotonNetwork.Disconnect();
    }
    void IPunObservable.OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            stream.SendNext(Health);
        }
        else
        {
            Health = (float)stream.ReceiveNext();
            Debug.Log(Health);
        }
    }

    public override void OnLeftRoom()
    {
        Debug.Log("ルームから退出しました");
    }

    public override void OnLeftLobby()
    {
        Debug.Log("ロビーから退出しました");
    }

    public override void OnDisconnected(DisconnectCause cause)
    {
        Debug.Log($"サーバーとの接続が切断されました: {cause.ToString()}");
        SceneManager.LoadScene("TitleScene");
    }
}

