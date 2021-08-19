using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{

    public GameObject bulletPrefab;
    float shotSpeed=1000;
    private float shotInterval;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            GameObject bullet = (GameObject)Instantiate(bulletPrefab, transform.position, Quaternion.Euler(transform.parent.eulerAngles.x, transform.parent.eulerAngles.y, 0));
            Rigidbody bulletRb = bullet.GetComponent<Rigidbody>();
            bulletRb.AddForce(transform.forward * shotSpeed);
        }
    }
}