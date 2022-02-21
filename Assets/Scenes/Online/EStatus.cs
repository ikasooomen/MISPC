using Photon.Pun;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EStatus : MonoBehaviour
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

    public float Health { get { return health; } }
    public float MaxHealth { get { return maxHealth; } }
    public float MaxTotalHealth { get { return maxTotalHealth; } }

    public void Heal(float health)
    {
        this.health += health;
        ClampHealth();
    }

    public void TakeDamage(float dmg)
    {
        health -= dmg;
        ClampHealth();
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

    private void Update()
    {
        if (flag == 0) {
            if (Status.Instance.Health == 0)
            {
                flag = 1;
                WL.text = "WIN";
                StartCoroutine(Timer());
            }
            else if (EStatus.Instance.Health == 0)
            {
                flag = 1;
                WL.text = "LOSE";
                StartCoroutine(Timer());
            }
        }
    }

    IEnumerator Timer()
    {
        //3•b‘Ò‚Â
        yield return new WaitForSeconds(5.0f);
        SceneManager.LoadScene("TitleScene");
    }
}
