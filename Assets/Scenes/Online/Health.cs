using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    private GameObject[] heartContainers;
    private Image[] heartFills;

    public Transform heartsParentr;
    public Transform heartsParentl;
    public GameObject heartContainerPrefab;

    int Flag = 0;
    GameObject objGet;

    Text WL;

    private void Update()
    {
        if (Flag == 0) {
            objGet = GameObject.Find("player(Clone)");
            Debug.Log("É}ÉWÇÌÇ©ÇÁÇÒ");
        }

        if (objGet!=null && Flag==0) {
            heartContainers = new GameObject[(int)Status.Instance.MaxTotalHealth];
            heartFills = new Image[(int)Status.Instance.MaxTotalHealth];

            Status.Instance.onHealthChangedCallback += UpdateHeartsHUD;
            InstantiateHeartContainers();
            UpdateHeartsHUD();

            Flag = 1;
            Debug.Log("ÇÌÇ©ÇÁÇÒ");
        }
    }

    public void UpdateHeartsHUD()
    {

        SetHeartContainers();
        SetFilledHearts();
    }

    void SetHeartContainers()
    {
        for (int i = 0; i < heartContainers.Length; i++)
        {
            if (i < Status.Instance.MaxHealth)
            {
                heartContainers[i].SetActive(true);
            }
            else
            {
                heartContainers[i].SetActive(false);
            }
        }
    }

    void SetFilledHearts()
    {
        for (int i = 0; i < heartFills.Length; i++)
        {
            if (i < Status.Instance.Health)
            {
                heartFills[i].fillAmount = 1;
            }
            else
            {
                heartFills[i].fillAmount = 0;
            }
        }

        if (Status.Instance.Health % 1 != 0)
        {
            int lastPos = Mathf.FloorToInt(Status.Instance.Health);
            heartFills[lastPos].fillAmount = Status.Instance.Health % 1;
        }
    }

    void InstantiateHeartContainers()
    {
        for (int i = 0; i < Status.Instance.MaxTotalHealth; i++)
        {
            GameObject temp = Instantiate(heartContainerPrefab);
            if (PhotonNetwork.IsMasterClient)
            {
                temp.transform.SetParent(heartsParentl, false);
            }
            else
            {
                temp.transform.SetParent(heartsParentr, false);
            }
            

            heartContainers[i] = temp;
            heartFills[i] = temp.transform.Find("HeartFill").GetComponent<Image>();
        }
    }

}




