using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shoot : MonoBehaviour
{
    public LayerMask layerMask;
    public QueryTriggerInteraction queryTriggerInteraction;
    GameObject scoreObject;
    float stk = -10f;
    bool hitHantei = false;
    public AudioClip se;
    AudioSource audiosource1;
    float bonus = 2.0f;
    bool ck = false;

    void Start()
    {
        scoreObject = GameObject.Find("ScriptIrerutoko");
        if (!PlayerPrefs.HasKey("gameStart")) PlayerPrefs.SetFloat("gameStart", 0);
        audiosource1 = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (bonus>=0&&ck)
        {
            bonus-= Time.deltaTime;
        }
        else
        {
            bonus = 2.0f;
        }

        if (scoreObject.GetComponent<CountText>().StartChecker() && Input.GetMouseButtonDown(0))
        {
            Debug.Log(PlayerPrefs.GetFloat("gameStart"));
            hitHantei = false;
            Ray ray = new Ray(transform.position + transform.rotation * new Vector3(0, 0, 0.01f), transform.forward);
            RaycastHit hit;
             if (Physics.Raycast(ray, out hit,10000.0f , layerMask, queryTriggerInteraction))
             {
                if (hit.collider.gameObject.tag == "Bullet"|| hit.collider.gameObject.tag == "Bullet2")
                {
                    if (ck) stk += 10f * bonus;
                    else stk += 10f;
                    ck = true;
                    hitHantei = true;
                    scoreObject.GetComponent<CountText>().AddScore(stk);
                    audiosource1.PlayOneShot(se);
                    Destroy(hit.collider.gameObject);
                }
                else
                {
                    stk = -10f;
                    ck = false;
                }
            }
            scoreObject.GetComponent<CountText>().NewHitrate(hitHantei);
        }
    }
}