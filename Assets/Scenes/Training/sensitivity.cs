using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class sensitivity: MonoBehaviour
{
    public new GameObject camera;
    [SerializeField] private Dropdown dropdown;
    void Start()
    {
        Cursor.visible = false;
    }

    void Update()
    {
        cameracon();
    }

    void cameracon()
    {
        float x_Rotation = Input.GetAxis("Mouse X");
        float y_Rotation = Input.GetAxis("Mouse Y");
        x_Rotation = x_Rotation * PlayerPrefs.GetFloat("sensi1"); 
        y_Rotation = y_Rotation * PlayerPrefs.GetFloat("sensi1");
        this.transform.Rotate(0, x_Rotation, 0);
        camera.transform.Rotate(-y_Rotation, 0, 0);
    }


}