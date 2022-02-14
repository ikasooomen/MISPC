using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Hit_destroy : MonoBehaviour
{
	private float tama_timer;
	private float deleteTime;
	public bool tama_red;

	public static int heart = 10;

	void Start()
    {
		
		GetComponent<Renderer>().material.color = new Color32(0,0,0,0);
		
		tama_red = false;
		deleteTime = 20f;
	}

	
	void OnCollisionEnter(Collision collision)
	{

		if (tama_red == true)
		{
			if (collision.gameObject.tag == "Bullet" || collision.gameObject.tag == "prpr")
			{

				Destroy(gameObject);
			}


			if (collision.gameObject.tag == "ATARIHANTEI")
			{
				float dmg = 1f;
				Destroy(gameObject);
				PlayerStats.Instance.TakeDamage(dmg);
				heart-=1;
			}
		}
	}

	void Update()
    {
		
		tama_timer+=Time.deltaTime;
		
        if (tama_timer >= 1f && tama_red == false)
        {
			
			GetComponent<Renderer>().material.color = new Color32(255,0,0,255);

			tama_red = true;
			this.tag = "Bullet";
		}
		Destroy(gameObject, deleteTime);


	}
}