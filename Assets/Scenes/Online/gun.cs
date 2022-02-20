using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gun : MonoBehaviour
{
    public LayerMask layerMask;
    public QueryTriggerInteraction queryTriggerInteraction;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = new Ray(transform.position + transform.rotation * new Vector3(0, 0, 0.01f), transform.forward);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 10000.0f, layerMask, queryTriggerInteraction))
            {
                if (hit.collider.gameObject.tag == "Bullet" || hit.collider.gameObject.tag == "Bullet2")
                {
                    Destroy(hit.collider.gameObject);
                }
            }

        }
    }
}