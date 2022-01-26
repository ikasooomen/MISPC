using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifePanel : MonoBehaviour
{
    public GameObject[] lifes;

    public void UpdateLife(int life)
    {
        for (int i = 0; i < lifes.Length; i++)
        {
            if (i < life) lifes[i].SetActive(true);
            else lifes[i].SetActive(false);
        }
    }
}