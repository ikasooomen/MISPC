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

    // 当たった時に呼ばれる関数
    void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.name == "stage") {


            void Update()
            {
                //自分の位置、ターゲット、速度
                transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed);
            }
        } 
    }
}