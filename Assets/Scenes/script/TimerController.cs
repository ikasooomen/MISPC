using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimerController : MonoBehaviour
{

	public GameObject StartTimer_object = null;
	public GameObject PlayTimer_object = null;

	public Text timerText;

	public float totalTime;
	public int seconds;


	public Text gametimerText;
	public float gameTime;
	int gamesec;

	float cnt = 2f;
	float cnt_2 = 2f;

	public  static Text score_text;
	public  static Text game_text;

	bool hpcheck = true;

	// Use this for initialization
	void Start()
	{
		score_text = StartTimer_object.GetComponent<Text>();
		game_text = PlayTimer_object.GetComponent<Text>();
	}

	// Update is called once per frame
	void Update()
	{
		cnt-= Time.deltaTime;
        if (hpcheck&& PlayerStats.Instance.Health == 0)
        {
			hpcheck = false;
			StartCoroutine(gameOver());
		}

		if (cnt<=0&&seconds >= 0)
		{
			totalTime -= Time.deltaTime;
			seconds = (int)totalTime;
            if (seconds == 0)
            {
				score_text.text = "GO!";
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
		if(score_text.text == ""|| score_text.text == "Game Over")
        {
			gameTime -= Time.deltaTime;
			gamesec = (int)gameTime;
			game_text.text = "残り " + gamesec + " 秒";

			if (gamesec < 0)
            {
				game_text.text = "";
				StartCoroutine(gameOver());
			}
        }

	}

	public void ChangeTitleSceneTimer()
	{
		SceneManager.LoadScene("TitleScene");
	}

	private  IEnumerator gameOver()
	{
		score_text.text = "Game Over";

		yield return new WaitForSeconds(2.0f);

		score_text.text = "タイトルに戻ります";

		yield return new WaitForSeconds(2.0f);
		Cursor.visible = true;
		Cursor.lockState = CursorLockMode.None;
		SceneManager.LoadScene("TitleScene");
	}

}