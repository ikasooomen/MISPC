using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class sensitivityUI : MonoBehaviour
{
    public GameObject Player;
    public Slider sensitivitybar;
    public InputField input;

    sensitivity SScript;

    
    
    void Start()
    {
        SScript = Player.GetComponent<sensitivity>();
        sensitivitybar = sensitivitybar.GetComponent<Slider>();
        input = input.GetComponent<InputField>();

        float maxHp = 10f;
        float nowHp = SScript.sensi;
        Debug.Log(nowHp);

        input.placeholder.GetComponent<Text>().text = nowHp.ToString();
        sensitivitybar.maxValue = maxHp;//�X���C�_�[�̍ő�l�̐ݒ�
        sensitivitybar.value = nowHp;//�X���C�_�[�̌��ݒl�̐ݒ�
    }

    void Update()
    {
        
    }

    public void ValueBar()
    {
        SScript.sensi = sensitivitybar.value;
        input.text = SScript.sensi.ToString();
    }

    public void ValueInput()
    {
        float num = float.Parse(input.text);
        if (num > 10) num = 10;
        else if (num < 0) num = 0;
        SScript.sensi = num;

        input.text = num.ToString();
        sensitivitybar.value = SScript.sensi;

    }


}