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
    float mouseDeltaPositionX, mouseDeltaPositionY,kaitenx,kaiteny;
    public static float dpi;
    float perdeg;
    bool ch;
    Vector2 prevPos;
    float x, y;
    Quaternion quaternion;
    float hipfire;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; 
        Cursor.visible = false;
        dpi = Screen.dpi;
        if (PlayerPrefs.GetFloat("game") == 0)
        {
            hipfire = 180 / (PlayerPrefs.GetFloat("dpi") * 0.022f * PlayerPrefs.GetFloat("sensi1")) * 2.54f;
        }
        else if (PlayerPrefs.GetFloat("game") == 1)
        {
            hipfire = 180 / (PlayerPrefs.GetFloat("dpi") * 0.07f * PlayerPrefs.GetFloat("sensi1")) * 2.54f;
        }
        perdeg = ((hipfire/180) / 2.54f) * dpi; //‚PƒsƒNƒZƒ‹“–‚½‚è‚Ì“x”
        perdeg = 1 / perdeg;
        ch = true;
        Debug.Log(hipfire);
        // prevPos = new Vector2(Screen.width / 2, Screen.height / 2);
        //Debug.Log("dpi:"+ perdeg);
        camera = GameObject.Find("PlayerCamera");
        //camera.transform.parent = transform;
    }

    void Update()
    {
        if (PlayerPrefs.GetFloat("game") == 0)
        {
            hipfire = 180 / (PlayerPrefs.GetFloat("dpi") * 0.022f * PlayerPrefs.GetFloat("sensi1")) * 2.54f;
        }
        else if (PlayerPrefs.GetFloat("game") == 1)
        {
            hipfire = 180 / (PlayerPrefs.GetFloat("dpi") * 0.07f * PlayerPrefs.GetFloat("sensi1")) * 2.54f;
        }
        perdeg = ((hipfire / 180) / 2.54f) * dpi; //‚P“x“–‚½‚è‚Ìpx
        perdeg = 1 / perdeg;

        if (settingPanel.activeSelf)
        {
            
        }
        else if (ch)
        {
            quaternion = camera.transform.rotation;
            x = camera.transform.localEulerAngles.x;
            y = camera.transform.localEulerAngles.y;
            prevPos = Input.mousePosition;
            ch = false;

        }
        else
        {
            cameracon();
        }
    }

    void cameracon()
    {
        Quaternion quaternion2 = camera.transform.rotation;
        kaitenx = quaternion2.eulerAngles.x - quaternion.eulerAngles.x;
        kaiteny = quaternion2.eulerAngles.y - quaternion.eulerAngles.y;
        quaternion = camera.transform.rotation;

        mouseDeltaPositionX = Input.mousePosition.x - prevPos.x;
        mouseDeltaPositionY = Input.mousePosition.y - prevPos.y;
        //Debug.Log("deltax:" + mouseDeltaPositionX + "  deltay:" + mouseDeltaPositionY + " axisx:" + Input.GetAxis("Mouse X") + "  axisy:" + Input.GetAxis("Mouse Y")+" kakudox:"+ kaitenx + " kakudoy:"+ kaiteny);
        prevPos = Input.mousePosition;

        float x_Rotation =Input.GetAxis("Mouse X") * 17.5f/7f * perdeg;
        float y_Rotation =Input.GetAxis("Mouse Y") * 17.5f/7f * - perdeg;
        

        /*x_Rotation = x_Rotation * PlayerPrefs.GetFloat("sensi1")/2; 
        y_Rotation = y_Rotation * PlayerPrefs.GetFloat("sensi1") * -1/2;


        float x_Rotation = mouseDeltaPositionX * perdeg;
        float y_Rotation = mouseDeltaPositionY * perdeg * (-1);*/


        float maxLimit = 85, minLimit = 0;
        minLimit = 360 - maxLimit;
        //XŽ²‰ñ“]
        var localAngle = camera.transform.localEulerAngles;
        localAngle.x += y_Rotation;
        if (localAngle.x > maxLimit && localAngle.x < 180)
            localAngle.x = maxLimit;
        if (localAngle.x < minLimit && localAngle.x > 180)
            localAngle.x = minLimit;
        localAngle.y += x_Rotation;
        camera.transform.localEulerAngles = localAngle;
        //YŽ²‰ñ“]
      /*  var angle = this.transform.eulerAngles;
        angle.y += x_Rotation;
        transform.eulerAngles = angle;*/
       // Debug.Log("deltax:" + mouseDeltaPositionX + "  deltay:" + mouseDeltaPositionY);
    }


}