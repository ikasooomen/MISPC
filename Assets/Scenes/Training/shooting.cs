using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shooting : MonoBehaviour
{

    public LayerMask layerMask;
    public QueryTriggerInteraction queryTriggerInteraction;
    public AudioClip se2;
    AudioSource audiosource2;
    void Start()
    {
        audiosource2 = GetComponent<AudioSource>();
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Ray ray = new Ray(transform.position + transform.rotation * new Vector3(0, 0, 0.01f), transform.forward);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit,10000.0f , layerMask, queryTriggerInteraction))
            {
                if (hit.collider.gameObject.tag == "Target") {
                    audiosource2.PlayOneShot(se2);
                    hit.collider.GetComponent<training>().Break();
                    //Debug.Log(hit.collider.gameObject.transform.position);
                }
            }
            Debug.DrawRay(ray.origin, ray.direction * 10, Color.red, 5);
        }
    }
}