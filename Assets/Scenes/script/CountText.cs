using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class CountText : MonoBehaviour
{
    int score = 0;
    public Text scoreText;
    public Text Hitrate;
    public float rate = 100f;
    float shootCount = 0;
    float hitCount = 0;

    public void AddScore(int plusScore)
    {
        score+= plusScore+1;
    }

    public void NewHitrate(bool ck)
    {
        shootCount++;
        if (ck) hitCount++;
        rate = (hitCount / shootCount)*100f;

    }

    void Update()
    {
        scoreText.text = "SCORE: " + score.ToString();
        string HitRateStr = rate.ToString("F1");
        Hitrate.text = HitRateStr + "%";
    }
}