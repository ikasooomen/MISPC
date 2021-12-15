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

    /*
    [SerializeField]
    [Tooltip("弾の速さ")]
    private float speed = 30f;

    [SerializeField]
    private float min = -15f; // ランダムの最小値
    [SerializeField]
    private float max = 15f;　// ランダムの最大値/

    */

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
        float maxSpeedY = 150f;//飛ばすときのY方向の最高速度(大きいほど角度が大きくなる)
        float maxSpeedX = 150f;
        float maxSpeedZ = 150f;


        // 弾を発射する場所を取得
        Vector3 bulletPosition = firingPoint.transform.position;
        // 上で取得した場所に、"bullet"のPrefabを出現させる
        GameObject newBall = Instantiate(bullet, bulletPosition, transform.rotation);

        Vector3 vel = new Vector3(0f,0f, 0f).normalized * speed;
        vel.y = Random.Range(-150f, maxSpeedY);
        vel.x = Random.Range(-150f, maxSpeedX);
        vel.z = Random.Range(-150f, maxSpeedZ);

        newBall.GetComponent<Rigidbody>().velocity = vel;
        
        // 出現させたボールの名前を"bullet"に変更
        newBall.name = bullet.name;
        // 出現させたボールを0.8秒後に消す
        Destroy(newBall, 40.0f);


        /*
        // 弾を発射する場所を取得
        Vector3 bulletPosition = firingPoint.transform.position;
        // 上で取得した場所に、"bullet"のPrefabを出現させる
        GameObject newBall = Instantiate(bullet, bulletPosition, transform.rotation);
        // 出現させたボールのforward(z軸方向)
        Vector3 force = new Vector3(Random.Range(min, max),    // X軸
                                      Random.Range(-15.0f, 15.0f), // Y軸
                                      Random.Range(min, max));   // Z軸
        Vector3 direction = newBall.transform.forward;

        print(Random.Range(min, max));

        // 弾の発射方向にnewBallのz方向(ローカル座標)を入れ、弾オブジェクトのrigidbodyに衝撃力を加える
        newBall.GetComponent<Rigidbody>().AddForce(direction * speed, ForceMode.Impulse);
        // 出現させたボールの名前を"bullet"に変更
        newBall.name = bullet.name;
        // 出現させたボールを0.8秒後に消す
        Destroy(newBall, 15.0f);
        */
    }
}