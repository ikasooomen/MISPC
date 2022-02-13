using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FireBullet : MonoBehaviour
{
    [SerializeField]
    [Tooltip("’e‚Ì”­ËêŠ")]
    public GameObject firingPoint;

    [SerializeField]
    [Tooltip("’e")]
    public GameObject bullet;


    [SerializeField]
    [Tooltip("’e‚Ì‘¬‚³")]
    public float Maxspeed = 150f;
    public float Minspeed = 30f;

    [SerializeField]
    [Tooltip("ŠÔ")]
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
    /// ’e‚Ì”­Ë
    /// </summary>
    public void LauncherShot()
    {
        float speed = Random.Range(Minspeed, Maxspeed);

        float MinAngle = 0f;
        float MaxAngle = 359f;


        // ’e‚ğ”­Ë‚·‚éêŠ‚ğæ“¾
        Vector3 bulletPosition = firingPoint.transform.position;


        float xkaku = Random.Range(MinAngle, MaxAngle);
        float ykaku = Random.Range(MinAngle, MaxAngle);
        float zkaku = Random.Range(MinAngle, MaxAngle);
        Quaternion kakudo = Quaternion.Euler(xkaku, ykaku, zkaku);
        GameObject newBall = Instantiate(bullet, bulletPosition, kakudo) as GameObject; 
        newBall.GetComponent<Rigidbody>().AddForce(newBall.transform.forward * speed, ForceMode.Impulse);


        // oŒ»‚³‚¹‚½ƒ{[ƒ‹‚Ì–¼‘O‚ğ"bullet"‚É•ÏX
        newBall.name = bullet.name;
        // oŒ»‚³‚¹‚½ƒ{[ƒ‹‚ğ0.8•bŒã‚ÉÁ‚·
    }
    void Start()
    {

    }
}