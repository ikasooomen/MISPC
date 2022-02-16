using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class sensitivity: MonoBehaviour
{
    public new GameObject camera;
    [SerializeField] private Dropdown dropdown;
    float angle = 0;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; 
        Cursor.visible = false;
        camera = GameObject.Find("PlayerCamera");
        //camera.transform.parent = transform;
    }

    void Update()
    {
        
        cameracon();
        
        
    }

    void cameracon()
    {
        float x_Rotation = Input.GetAxis("Mouse X");
        float y_Rotation = Input.GetAxis("Mouse Y");
        x_Rotation = x_Rotation * PlayerPrefs.GetFloat("sensi1")/2; 
        y_Rotation = y_Rotation * PlayerPrefs.GetFloat("sensi1") * -1/2;
        float maxLimit = 85, minLimit = 0;
        minLimit = 360 - maxLimit;
        //XŽ²‰ñ“]
        var localAngle = camera.transform.localEulerAngles;
        localAngle.x += y_Rotation;
        if (localAngle.x > maxLimit && localAngle.x < 180)
            localAngle.x = maxLimit;
        if (localAngle.x < minLimit && localAngle.x > 180)
            localAngle.x = minLimit;
        camera.transform.localEulerAngles = localAngle;
        //YŽ²‰ñ“]
        var angle = camera.transform.eulerAngles;
        angle.y += x_Rotation;
        camera.transform.eulerAngles = angle;
    }


}