using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeMove : MonoBehaviour
{
    public GameObject target;
    public GameObject target2;
    [SerializeField] float speed;

    int check = 0;


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) check = 1;

        //自分の位置、ターゲット、速度
        if (check == 1)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed);
        }

        else if (check == 2)
        {
            transform.position = Vector3.MoveTowards(transform.position, target2.transform.position, speed);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.name); // ログを表示する
        check = 2;
        if (collision.gameObject.name == "Cylinder") check = 0;
    }
}