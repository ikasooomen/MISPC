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
	public bool tama_blue;

	public static int heart = 10;

	void Start()
    {
		
		GetComponent<Renderer>().material.color = new Color32(0,0,0,0);
		
		tama_red = false;
		tama_blue = false;
		deleteTime = 20f;
	}

	
	void OnCollisionEnter(Collision collision)
	{

		if (tama_red == true||tama_blue==true)
		{
			if (collision.gameObject.tag == "Bullet2" || collision.gameObject.tag == "Bullet" || collision.gameObject.tag == "prpr")
			{

				Destroy(gameObject);
			}


			if (this.tag=="Bullet2"&&collision.gameObject.name == "AH_p1")
			{
				float dmg = 1f;
				Destroy(gameObject);
				PlayerStats.Instance.TakeDamage(dmg);
			}

			else if (this.tag== "Bullet"&&collision.gameObject.name == "AH_p2")
			{
				float dmg = 1f;
				Destroy(gameObject);
				//PlayerStats.Instance.TakeDamage(dmg);
			}
		}
	}

	void Update()
    {
		
		tama_timer+=Time.deltaTime;
		
        if (tama_timer >= 0.8f && this.name== "bullet_player1" && tama_red == false)
        {
			
			GetComponent<Renderer>().material.color = new Color32(255,0,0,255);

			tama_red = true;
			this.tag = "Bullet";
		}

		if (tama_timer >= 0.8f && this.name == "bullet_player2" && tama_blue == false)
		{

			GetComponent<Renderer>().material.color = new Color32(0, 0, 255, 255);

			tama_blue = true;
			this.tag = "Bullet2";
		}
		Destroy(gameObject, deleteTime);


	}
}