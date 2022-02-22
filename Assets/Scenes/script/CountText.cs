using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class CountText : MonoBehaviour
{
    int score = 0;
    public Text scoreText;
    public Text Hitrate;
    public float rate = 100f;
    float shootCount = 0;
    float hitCount = 0;


    public GameObject StartTimer_object = null;
    public GameObject PlayTimer_object = null;

    public Text timerText;

    public float totalTime;
    public int seconds;


    public Text gametimerText;
    public float gameTime = 70f;
    int gamesec;
    string HitRateStr;

    float cnt = 2f;
    float cnt_2 = 2f;

    public static Text score_text;
    public static Text game_text;

    bool hpcheck = true;
    bool SC = false;

    GameObject resultObject;

    void Start()
    {
        score_text = StartTimer_object.GetComponent<Text>();
        game_text = PlayTimer_object.GetComponent<Text>();

        resultObject = GameObject.Find("ResultController");
        if (!PlayerPrefs.HasKey("gameEnd")) PlayerPrefs.SetFloat("gameEnd", 0);
    }
    public void AddScore(float plusScore)
    {
        score+= (int)plusScore+100;
    }

    public void NewHitrate(bool ck)
    {
            shootCount++;
            if (ck) hitCount++;
            rate = (hitCount / shootCount) * 100f;
    }

    public bool StartChecker()
    {
        return SC;
    }

    void Update()
    {

        cnt -= Time.deltaTime;
        if (hpcheck && PlayerStats.Instance.Health == 0)
        {
            hpcheck = false;
            StartCoroutine(gameOver());
        }

        if (cnt <= 0 && seconds >= 0)
        {
            totalTime -= Time.deltaTime;
            seconds = (int)totalTime;
            if (seconds == 0)
            {
                score_text.text = "GO!";
                SC = true;
            }
            else if (totalTime < -0.3f)
            {
                score_text.text = "";
            }
            else
            {
                timerText.text = seconds.ToString();
            }
        }
        if (score_text.text == "" || score_text.text == "Game Over")
        {
            gameTime -= Time.deltaTime;
            gamesec = (int)gameTime;
            game_text.text =gamesec/60+":" +(gamesec%60).ToString("D2");

            if (gamesec < 0)
            {
                game_text.text = "";
                StartCoroutine(gameOver());
            }
        }

        scoreText.text = "SCORE: " + score.ToString();
        HitRateStr = rate.ToString("F1");
        Hitrate.text = HitRateStr + "%";
    }

    private IEnumerator gameOver()
    {
        SC = false;
        if (gamesec < 0) gamesec = 0;
        resultObject.GetComponent<ResultSetting>().getScore(score.ToString());
        resultObject.GetComponent<ResultSetting>().getTime((70-gamesec).ToString());
        resultObject.GetComponent<ResultSetting>().getHitRate(HitRateStr);

        score_text.text = "Game Over";

        yield return new WaitForSeconds(2.0f);

        PlayerPrefs.SetFloat("gameEnd", 1);
        /*score_text.text = "ƒ^ƒCƒgƒ‹‚É–ß‚è‚Ü‚·";

        yield return new WaitForSeconds(2.0f);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        SceneManager.LoadScene("TitleScene");*/
    }
}