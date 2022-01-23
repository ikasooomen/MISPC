using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FireBullet : MonoBehaviour
{
    [SerializeField]
    [Tooltip("弾の発射場所")]
    private GameObject firingPoint;

    [SerializeField]
    [Tooltip("弾")]
    private GameObject bullet;


    [SerializeField]
    [Tooltip("弾の速さ")]
    private float speed = 30f;

    // Update is called once per frame
    void Update()
    {
        // スペースキーが押されたかを判定
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // 弾を発射する
            LauncherShot();
        }
    }

    /// <summary>
    /// 弾の発射
    /// </summary>
    private void LauncherShot()
    {
        float speed = 100f;//飛ばすときの初速度

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

}