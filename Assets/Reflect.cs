using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reflect : MonoBehaviour
{
    public GameObject target;

    [SerializeField] float speed;

    void Start()
    {
        target = GameObject.Find("player2");
    }

    // �����������ɌĂ΂��֐�
    void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.name == "stage") {


            void Update()
            {
                //�����̈ʒu�A�^�[�Q�b�g�A���x
                transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed);
            }
        } 
    }
}