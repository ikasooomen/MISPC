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
		//�ʂ̐F�𓧖��ɂ���
		GetComponent<Renderer>().material.color = new Color32(0,0,0,0);
		//�F��߂����������true�ɂȂ�
		tama_red = false;
		deleteTime = 20f;
	}

	//�ʂ��Ȃ񂩂ɓ������������
	void OnCollisionEnter(Collision collision)
	{
		//�F���߂�Ă�
		if(tama_red == true)
        {
			//�v���C���[��������e�ɓ��������
			if (collision.gameObject.tag == "Bullet" || collision.gameObject.tag == "prpr")
			{
				//�ʂ���
				Destroy(gameObject);
			}


		if (collision.gameObject.tag == "ATARIHANTEI")
		{
			float dmg = 0.25f;
			Destroy(gameObject);
			PlayerStats.Instance.TakeDamage(dmg);

		}
		
	}

	void Update()
    {
		//���Ԃ�0����J�E���g�A�b�v
		tama_timer+=Time.deltaTime;
		//�ʂ���������Ă���1�b��ŁA�ʂ̐F�������ł��鎞
        if (tama_timer >= 1f && tama_red == false)
        {
			//�ʂ̐F��Ԃɂ���
			GetComponent<Renderer>().material.color = new Color32(255,0,0,255);
			//�ʂ̐F���ԂɂȂ�����Ƃ�L�^
			tama_red = true;
			this.tag = "Bullet";
		}
		Destroy(gameObject, deleteTime);
	}
}