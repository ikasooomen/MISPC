using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Photon.Pun;

public class Bullet : MonoBehaviourPunCallbacks, IPunObservable
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

    Vector3 bulletPosition;
    Quaternion kakudo;
    float speed;
    int id=0;
    // Update is called once per frame
    void Update()
    {
        tmpTime += Time.deltaTime;
        startcooldown -= Time.deltaTime;
        doubletamatama -= Time.deltaTime;
        if (photonView.IsMine) {
            if (startcooldown <= 1f) start = true;
            if (start == true && tmpTime >= interval)
            {

                LauncherShot();
                doubletamatamacount++;
                if (doubletamatama < 0 && doubletamatamacount % 2 == 0)
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
        else
        {
            if (startcooldown <= 1f) start = true;
            if (start == true && tmpTime >= interval)
            {

                LauncherShot2();
                doubletamatamacount++;
                if (doubletamatama < 0 && doubletamatamacount % 2 == 0)
                {
                    LauncherShot2();
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
    }

    /// <summary>
    /// 弾の発射
    /// </summary>
    public void LauncherShot()
    {

        Maxspeed = 300f;
        Minspeed = 100f;
        interval = 0.75f;

        speed = Random.Range(Minspeed, Maxspeed);

        float MinAngle = 0f;
        float MaxAngle = 359f;


        // 弾を発射する場所を取得
        bulletPosition = firingPoint.transform.position;


        float xkaku = Random.Range(MinAngle, MaxAngle);
        float ykaku = Random.Range(MinAngle, MaxAngle);
        float zkaku = Random.Range(MinAngle, MaxAngle);
        kakudo = Quaternion.Euler(xkaku, ykaku, zkaku);
        GameObject newBall = Instantiate(bullet, bulletPosition, kakudo) as GameObject;

        if (firingPoint.name == "player")
        {
            newBall.name = "bullet_player1";
            newBall.name = (id).ToString();
            newBall.tag = "Bullet";

        }
        if (firingPoint.name == "player2(Clone)")
        {
            newBall.name = "bullet_player1";
            newBall.name = (id).ToString();
            newBall.tag = "Bullet";
        }

        else
        {
            newBall.name = "bullet_player2";
            newBall.name = (id).ToString();
            newBall.tag = "Bullet2";
        }
        id++;
        newBall.GetComponent<Rigidbody>().AddForce(newBall.transform.forward * speed, ForceMode.Impulse);


        // 出現させたボールの名前を"bullet"に変更
        // 出現させたボールを20秒後に消す


    }
    public void LauncherShot2()
    {

        Maxspeed = 300f;
        Minspeed = 100f;
        interval = 0.75f;

        // 弾を発射する場所を取得
        bulletPosition = firingPoint.transform.position;
        GameObject newBall = Instantiate(bullet, bulletPosition, kakudo) as GameObject;

        if (firingPoint.name == "player")
        {
            newBall.name = (id).ToString();
            newBall.tag = "Bullet";

        }
        if (firingPoint.name == "player2(Clone)")
        {
            newBall.name = (id).ToString();
            newBall.tag = "Bullet";
        }

        else
        {
            newBall.name = (id).ToString();
            newBall.tag = "Bullet2";
        }

        newBall.GetComponent<Rigidbody>().AddForce(newBall.transform.forward * speed, ForceMode.Impulse);


        // 出現させたボールの名前を"bullet"に変更
        // 出現させたボールを20秒後に消す


    }

    void IPunObservable.OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            stream.SendNext(bulletPosition);
            stream.SendNext(kakudo);
            stream.SendNext(speed);
            stream.SendNext(id+1000);
        }
        else
        {
            bulletPosition = (Vector3)stream.ReceiveNext();
            kakudo = (Quaternion)stream.ReceiveNext();
            speed = (float)stream.ReceiveNext();
            id = (int)stream.ReceiveNext();
        }
    }

}