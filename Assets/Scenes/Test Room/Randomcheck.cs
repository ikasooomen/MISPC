using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Randomcheck : MonoBehaviour
{
    // ���̔��a
    [SerializeField] private float _radius = 5;

    // ���̒��S�_
    [SerializeField] private Vector3 _center;

    [SerializeField] public GameObject obj;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) {
            randomchecker();
        }
    }

    void randomchecker()
    {
        Vector3 position = _radius * Random.insideUnitSphere + _center;

        obj.transform.LookAt(position);

        Debug.Log(position);
    }
}
