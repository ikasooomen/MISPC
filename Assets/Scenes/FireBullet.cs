using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FireBullet : MonoBehaviour
{
    [SerializeField]
    [Tooltip("�e�̔��ˏꏊ")]
    public GameObject firingPoint;

    [SerializeField]
    [Tooltip("�e")]
    public GameObject bullet;


    [SerializeField]
    [Tooltip("�e�̑���")]
    public float Maxspeed = 150f;
    public float Minspeed = 30f;

    [SerializeField]
    [Tooltip("����")]
    public float interval = 1f;

    [SerializeField]
    public float tmpTime = 0;

    private bool start = false;

    float startcooldown = 6f;
    // Update is called once per frame
    void Update()
    {
        tmpTime += Time.deltaTime;
        startcooldown -= Time.deltaTime;
        if (startcooldown <= 1f) start = true;

        if (start==true&&tmpTime >= interval)
        {

            LauncherShot();

            tmpTime = 0;
        }
    }

    /// <summary>
    /// �e�̔���
    /// </summary>
    public void LauncherShot()
    {
        float speed = Random.Range(Minspeed, Maxspeed);

        float MinAngle = 0f;
        float MaxAngle = 359f;


        // �e�𔭎˂���ꏊ���擾
        Vector3 bulletPosition = firingPoint.transform.position;


        float xkaku = Random.Range(MinAngle, MaxAngle);
        float ykaku = Random.Range(MinAngle, MaxAngle);
        float zkaku = Random.Range(MinAngle, MaxAngle);
        Quaternion kakudo = Quaternion.Euler(xkaku, ykaku, zkaku);
        GameObject newBall = Instantiate(bullet, bulletPosition, kakudo) as GameObject; 
        newBall.GetComponent<Rigidbody>().AddForce(newBall.transform.forward * speed, ForceMode.Impulse);


        // �o���������{�[���̖��O��"bullet"�ɕύX
        newBall.name = bullet.name;
        // �o���������{�[����0.8�b��ɏ���
    }
    void Start()
    {

    }
}