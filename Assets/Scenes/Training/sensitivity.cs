using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class sensitivity: MonoBehaviour
{
    public float sensi=3;
    public new GameObject camera;

    void Start()
    {
    }

    void Update()
    {
        cameracon();
    }

    void cameracon()
    {
        float x_Rotation = Input.GetAxis("Mouse X");
        float y_Rotation = Input.GetAxis("Mouse Y");
        x_Rotation = x_Rotation * sensi;
        y_Rotation = y_Rotation * sensi;
        this.transform.Rotate(0, x_Rotation, 0);
        camera.transform.Rotate(-y_Rotation, 0, 0);
    }
}