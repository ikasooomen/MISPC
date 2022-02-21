using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shoot : MonoBehaviour
{
    public LayerMask layerMask;
    public QueryTriggerInteraction queryTriggerInteraction;
    GameObject scoreObject;
    int stk = -1;
    bool hitHantei = false;

    void Start()
    {
        scoreObject = GameObject.Find("ScriptIrerutoko");
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            hitHantei = false;
            Ray ray = new Ray(transform.position + transform.rotation * new Vector3(0, 0, 0.01f), transform.forward);
            RaycastHit hit;
             if (Physics.Raycast(ray, out hit,10000.0f , layerMask, queryTriggerInteraction))
             {
                if (hit.collider.gameObject.tag == "Bullet"|| hit.collider.gameObject.tag == "Bullet2")
                {
                    stk++;
                    hitHantei = true;
                    scoreObject.GetComponent<CountText>().AddScore(stk);
                    Destroy(hit.collider.gameObject);
                }
                else
                {
                    stk = -1;
                }
            }
            scoreObject.GetComponent<CountText>().NewHitrate(hitHantei);
        }
    }
}