using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hit_destroy : MonoBehaviour
{

	void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.tag == "Bullet")
		{
			Destroy(collision.gameObject);
			Destroy(gameObject);
		}

		if (collision.gameObject.tag == "ATARIHANTEI")
		{
			Destroy(gameObject);
		}
	}

}