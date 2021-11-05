using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class sensitivityUI : MonoBehaviour
{
    public Slider sensitivitybar;
    public InputField input;   
    
    void Start()
    {
        if (!PlayerPrefs.HasKey("sensi1"))
        {
            PlayerPrefs.SetFloat("sensi1", 3);
        }

        sensitivitybar = sensitivitybar.GetComponent<Slider>();
        input = input.GetComponent<InputField>();

        float maxHp = 10f;
        float nowHp = PlayerPrefs.GetFloat("sensi1");
        Debug.Log(nowHp);

        input.placeholder.GetComponent<Text>().text = nowHp.ToString();
        sensitivitybar.maxValue = maxHp;//スライダーの最大値の設定
        sensitivitybar.value = nowHp;//スライダーの現在値の設定
    }

    void Update()
    {
        
    }



    public void ValueBar()
    {
        PlayerPrefs.SetFloat("sensi1", sensitivitybar.value);
        input.text = PlayerPrefs.GetFloat("sensi1").ToString();
    }

    public void ValueInput()
    {
        float num = float.Parse(input.text);
        if (num > 10) num = 10;
        else if (num < 0) num = 0;
        PlayerPrefs.SetFloat("sensi1",num);

        input.text = num.ToString();
        sensitivitybar.value = PlayerPrefs.GetFloat("sensi1");

    }


}