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

        //ぶつかったオブジェクトのTagにShellという名前が書いてあったならば（条件）.
        if (other.CompareTag("Shell"))
        {
            Count();

            //ぶつかってきたオブジェクトを破壊する.
            Destroy(other.gameObject);
        }
    }
}
