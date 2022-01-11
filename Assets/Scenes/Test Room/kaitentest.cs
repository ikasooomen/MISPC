using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kaitentest : MonoBehaviour
{

    [SerializeField]
    private float MinAngle;

    [SerializeField]
    private float MaxAngle;

    [SerializeField]
    private GameObject obj;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // ’e‚ð”­ŽË‚·‚é
            kaiten();
        }
    }

    void kaiten()
    {
        Vector3 bulletPosition = obj.transform.position;

        float xkaku = Random.Range(MinAngle, MaxAngle);
        float ykaku = Random.Range(MinAngle, MaxAngle);
        float zkaku = Random.Range(MinAngle, MaxAngle);
        Quaternion kakudo = Quaternion.Euler(xkaku, ykaku, zkaku);

    }
}
