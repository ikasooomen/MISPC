using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hit_destroy : MonoBehaviour
{
	private float tama_timer;
	private float deleteTime;
	public bool tama_red;


	void Start()
    {
		//玉の色を透明にする
		GetComponent<Renderer>().material.color = new Color32(0,0,0,0);
		//色を戻す処理をしたらtrueになる
		tama_red = false;
		deleteTime = 20f;
	}

	//玉がなんかに当たった時発動
	void OnCollisionEnter(Collision collision)
	{
		//色が戻ってて
		if(tama_red == true)
        {
			//プレイヤーが撃った弾に当たった時
			if (collision.gameObject.tag == "Bullet" || collision.gameObject.tag == "prpr")
			{
				//玉を消す
				Destroy(gameObject);
			}

			//敵プレイヤーに当たった時
			if (collision.gameObject.tag == "ATARIHANTEI")
			{
				//玉を消す
				Destroy(gameObject);
			}
		}
		
	}

	void Update()
    {
		//時間を0からカウントアップ
		tama_timer+=Time.deltaTime;
		//玉が生成されてから1秒後で、玉の色が透明である時
        if (tama_timer >= 1f && tama_red == false)
        {
			//玉の色を赤にする
			GetComponent<Renderer>().material.color = new Color32(255,0,0,255);
			//玉の色が赤になったことを記録
			tama_red = true;
			this.tag = "Bullet";
		}
		Destroy(gameObject, deleteTime);
	}
}