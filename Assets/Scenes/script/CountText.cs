using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountText : MonoBehaviour
{
    int score = 0;
    public Text scoreText;

    public void AddScore(int plusScore)
    {
        score+= plusScore+1;
    }

    void Update()
    {
        scoreText.text = "SCORE: " + score.ToString();
    }
}