using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FireBullet : MonoBehaviour
{
    [SerializeField]
    [Tooltip("�e�̔��ˏꏊ")]
    private GameObject firingPoint;

    [SerializeField]
    [Tooltip("�e")]
    private GameObject bullet;

    /*
    [SerializeField]
    [Tooltip("�e�̑���")]
    private float speed = 30f;

    [SerializeField]
    private float min = -15f; // �����_���̍ŏ��l
    [SerializeField]
    private float max = 15f;�@// �����_���̍ő�l/

    */

    // Update is called once per frame
    void Update()
    {
        // �X�y�[�X�L�[�������ꂽ���𔻒�
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // �e�𔭎˂���
            LauncherShot();
        }
    }

    /// <summary>
    /// �e�̔���
    /// </summary>
    private void LauncherShot()
    {
        float speed = 100f;//��΂��Ƃ��̏����x
        float maxSpeedY = 150f;//��΂��Ƃ���Y�����̍ō����x(�傫���قǊp�x���傫���Ȃ�)
        float maxSpeedX = 150f;
        float maxSpeedZ = 150f;


        // �e�𔭎˂���ꏊ���擾
        Vector3 bulletPosition = firingPoint.transform.position;
        // ��Ŏ擾�����ꏊ�ɁA"bullet"��Prefab���o��������
        GameObject newBall = Instantiate(bullet, bulletPosition, transform.rotation);

        Vector3 vel = new Vector3(0f,0f, 0f).normalized * speed;
        vel.y = Random.Range(-150f, maxSpeedY);
        vel.x = Random.Range(-150f, maxSpeedX);
        vel.z = Random.Range(-150f, maxSpeedZ);

        newBall.GetComponent<Rigidbody>().velocity = vel;
        
        // �o���������{�[���̖��O��"bullet"�ɕύX
        newBall.name = bullet.name;
        // �o���������{�[����0.8�b��ɏ���
        Destroy(newBall, 40.0f);


        /*
        // �e�𔭎˂���ꏊ���擾
        Vector3 bulletPosition = firingPoint.transform.position;
        // ��Ŏ擾�����ꏊ�ɁA"bullet"��Prefab���o��������
        GameObject newBall = Instantiate(bullet, bulletPosition, transform.rotation);
        // �o���������{�[����forward(z������)
        Vector3 force = new Vector3(Random.Range(min, max),    // X��
                                      Random.Range(-15.0f, 15.0f), // Y��
                                      Random.Range(min, max));   // Z��
        Vector3 direction = newBall.transform.forward;

        print(Random.Range(min, max));

        // �e�̔��˕�����newBall��z����(���[�J�����W)�����A�e�I�u�W�F�N�g��rigidbody�ɏՌ��͂�������
        newBall.GetComponent<Rigidbody>().AddForce(direction * speed, ForceMode.Impulse);
        // �o���������{�[���̖��O��"bullet"�ɕύX
        newBall.name = bullet.name;
        // �o���������{�[����0.8�b��ɏ���
        Destroy(newBall, 15.0f);
        */
    }
}