using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyCount : MonoBehaviour
{
    public int count = 0;
    public Text text;
   
    // Update is called once per frame
    void Update()
    {
        text.text = count+"";
    }

    public void Count()
    {
        count++;
    }

    void OnTriggerEnter(Collider other)
    {

        //�Ԃ������I�u�W�F�N�g��Tag��Shell�Ƃ������O�������Ă������Ȃ�΁i�����j.
        if (other.CompareTag("Shell"))
        {
            Count();

            //�Ԃ����Ă����I�u�W�F�N�g��j�󂷂�.
            Destroy(other.gameObject);
        }
    }
}
