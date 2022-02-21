using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FireBullet : MonoBehaviour
{
    private float timer;


    [SerializeField]
    [Tooltip("弾の発射場所")]
    public GameObject firingPoint;

    [SerializeField]
    [Tooltip("弾")]
    public GameObject bullet;


    [SerializeField]
    [Tooltip("弾の速さ")]
    public float Maxspeed = 600f;
    public float Minspeed = 100f;

    [SerializeField]
    [Tooltip("時間")]
    public float interval = 0.75f;

    [SerializeField]
    public float tmpTime = 0;

    private bool start = false;
    float doubletamatama = 45f;
    float startcooldown = 6f;
    int doubletamatamacount = 0;
    // Update is called once per frame
    void Update()
    {
        tmpTime += Time.deltaTime;
        startcooldown -= Time.deltaTime;
        doubletamatama-= Time.deltaTime;

        if (startcooldown <= 1f) start = true;
        if (start==true&&tmpTime >= interval)
        {

            LauncherShot();
            doubletamatamacount++;
            if (doubletamatama < 0&& doubletamatamacount%2==0)
            {
                LauncherShot();
            }
            tmpTime = 0;
        }

        timer += Time.deltaTime;

        if (timer >= 2f && interval > 0.55f)
        {
            interval -= 0.01f;
            timer = 0f;
            //Debug.Log(interval);
        }
    }

    /// <summary>
    /// 弾の発射
    /// </summary>
    public void LauncherShot()
    {

        Maxspeed = 300f;
        Minspeed = 100f;
        interval = 0.75f;

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

        if (firingPoint.name == "player")
        {
            newBall.name = "bullet_player1";
        }
        if (firingPoint.name == "player2(Clone)")
        {
            newBall.name = "bullet_player1";
        }

        else
        {
            newBall.name = "bullet_player2";
        }

        newBall.GetComponent<Rigidbody>().AddForce(newBall.transform.forward * speed, ForceMode.Impulse);


        // 出現させたボールの名前を"bullet"に変更
        // 出現させたボールを20秒後に消す

        
    }

}