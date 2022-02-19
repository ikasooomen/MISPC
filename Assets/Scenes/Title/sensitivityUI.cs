using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class sensitivityUI : MonoBehaviour
{
    public Slider sensitivitybar;
    public InputField input;
    public InputField inputDPI;

    void Start()
    {
        if (!PlayerPrefs.HasKey("sensi1"))
        {
            PlayerPrefs.SetFloat("sensi1", 3);
        }

        if (!PlayerPrefs.HasKey("dpi"))
        {
            PlayerPrefs.SetFloat("dpi", 800);
        }

        sensitivitybar = sensitivitybar.GetComponent<Slider>();
        input = input.GetComponent<InputField>();
        inputDPI = inputDPI.GetComponent<InputField>();
        inputDPI.text = PlayerPrefs.GetFloat("dpi").ToString();

        float maxHp = 10f;
        float nowHp = PlayerPrefs.GetFloat("sensi1");
        Debug.Log(nowHp);
        Debug.Log(PlayerPrefs.GetFloat("dpi"));

        input.placeholder.GetComponent<Text>().text = nowHp.ToString();
        sensitivitybar.maxValue = maxHp;//�X���C�_�[�̍ő�l�̐ݒ�
        sensitivitybar.value = nowHp;//�X���C�_�[�̌��ݒl�̐ݒ�
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
        if (num > 10f) num = 10f;
        else if (num < 0f) num = 0.2f;
        PlayerPrefs.SetFloat("sensi1",num);

        input.text = num.ToString();
        sensitivitybar.value = PlayerPrefs.GetFloat("sensi1");

    }

    public void ValueInputDPI()
    {
        float num = float.Parse(inputDPI.text);
        if (num > 20000f) num = 20000f;
        else if (num < 100f) num = 100f;
        PlayerPrefs.SetFloat("dpi", num);

        inputDPI.text = PlayerPrefs.GetFloat("dpi").ToString();

    }

}