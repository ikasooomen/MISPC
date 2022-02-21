using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartTimer : MonoBehaviour
{
	public Text timerText;

	public float totalTime;
	int seconds;

	// Use this for initialization
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{
		totalTime -= Time.deltaTime;
		seconds = (int)totalTime;
		if (seconds == 0)
			{
				timerText.text = "GO!";
			}
			else if (totalTime < -0.3f)
			{
				timerText.text = "";
			}
			else
			{
				timerText.text = seconds.ToString();
			}
	}
}