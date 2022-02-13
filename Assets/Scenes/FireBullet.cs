using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FireBullet : MonoBehaviour
{
    [SerializeField]
    [Tooltip("弾の発射場所")]
    public GameObject firingPoint;

    [SerializeField]
    [Tooltip("弾")]
    public GameObject bullet;


    [SerializeField]
    [Tooltip("弾の速さ")]
    public float Maxspeed = 150f;
    public float Minspeed = 30f;

    [SerializeField]
    [Tooltip("時間")]
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
    /// 弾の発射
    /// </summary>
    public void LauncherShot()
    {
        float speed = Random.Range(Minspeed, Maxspeed);

        float MinAngle = 0f;
        float MaxAngle = 359f;


        // 弾を発射する場所を取得
        Vector3 bulletPosition = firingPoint.transform.position;


        float xkaku = Random.Range(MinAngle, MaxAngle);
        float ykaku = Random.Range(MinAngle, MaxAngle);
        float zkaku = Random.Range(MinAngle, MaxAngle);
        Quaternion kakudo = Quaternion.Euler(xkaku, ykaku, zkaku);
        GameObject newBall = Instantiate(bullet, bulletPosition, kakudo) as GameObject; 
        newBall.GetComponent<Rigidbody>().AddForce(newBall.transform.forward * speed, ForceMode.Impulse);


        // 出現させたボールの名前を"bullet"に変更
        newBall.name = bullet.name;
        // 出現させたボールを0.8秒後に消す
    }
    void Start()
    {

    }
}