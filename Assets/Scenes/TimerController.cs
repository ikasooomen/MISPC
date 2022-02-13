using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerController : MonoBehaviour
{

	public GameObject StartTimer_object = null;

	public Text timerText;

	public float totalTime;
	public int seconds;

	float cnt = 2f;

	// Use this for initialization
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{
		cnt-= Time.deltaTime;

		Text score_text = StartTimer_object.GetComponent<Text>();

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
	}
}