using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class sensitivity: MonoBehaviour
{
    public new GameObject camera;
    [SerializeField] private Dropdown dropdown;
    float angle = 0;
    float hipfire,perdeg;
    public static float dpi;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; 
        Cursor.visible = false;
        dpi = Screen.dpi;
        if (PlayerPrefs.GetFloat("game") == 0)
        {
            hipfire = 180 / (PlayerPrefs.GetFloat("DPI") * 0.022f * PlayerPrefs.GetFloat("sensi1")) * 2.54f;
        }
        else if (PlayerPrefs.GetFloat("game") == 1)
        {
            hipfire = 180 / (PlayerPrefs.GetFloat("DPI") * 0.07f * PlayerPrefs.GetFloat("sensi1")) * 2.54f;
        }
        perdeg = 1 / (((hipfire / 180) / 2.54f) * dpi);
        camera = GameObject.Find("PlayerCamera");
        //camera.transform.parent = transform;
    }

    void Update()
    {
        if (PlayerPrefs.GetFloat("game") == 0)
        {
            hipfire = 180 / (PlayerPrefs.GetFloat("DPI") * 0.022f * PlayerPrefs.GetFloat("sensi1")) * 2.54f;
        }
        else if (PlayerPrefs.GetFloat("game") == 1)
        {
            hipfire = 180 / (PlayerPrefs.GetFloat("DPI") * 0.07f * PlayerPrefs.GetFloat("sensi1")) * 2.54f;
        }
        perdeg = 1 / (((hipfire / 180) / 2.54f) * dpi);

        cameracon();
    }

    void cameracon()
    {
        float x_Rotation = Input.GetAxis("Mouse X") * 17.5f / 7f * perdeg;
        float y_Rotation = Input.GetAxis("Mouse Y") * 17.5f / 7f * -perdeg;
        float maxLimit = 85, minLimit = 0;
        minLimit = 360 - maxLimit;
        //X軸回転
        var localAngle = camera.transform.localEulerAngles;
        localAngle.x += y_Rotation;
        if (localAngle.x > maxLimit && localAngle.x < 180)
            localAngle.x = maxLimit;
        if (localAngle.x < minLimit && localAngle.x > 180)
            localAngle.x = minLimit;
        camera.transform.localEulerAngles = localAngle;
        //Y軸回転
        var angle = camera.transform.eulerAngles;
        angle.y += x_Rotation;
        camera.transform.eulerAngles = angle;
    }


}