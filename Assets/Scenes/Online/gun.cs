using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gun : MonoBehaviourPunCallbacks, IPunObservable
{
    public LayerMask layerMask;
    public QueryTriggerInteraction queryTriggerInteraction;
    public string Oname;
    GameObject dest;
    private AudioSource sound01;

    void Start()
    {
        sound01 = GetComponent<AudioSource>();
    }
    void Update()
    {
        if (photonView.IsMine)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = new Ray(this.transform.position + this.transform.rotation * new Vector3(0, 0, 0.01f), this.transform.forward);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit, 10000.0f, layerMask, queryTriggerInteraction))
                {
                    Debug.DrawRay(this.transform.position + this.transform.rotation * new Vector3(0, 0, 0.01f), transform.forward * 600, Color.red, 6.1f);
                    if (hit.collider.gameObject.tag == "Bullet" || hit.collider.gameObject.tag == "Bullet2")
                    {
                        Debug.Log("darudaru2");
                        Oname = hit.collider.gameObject.name;
                        sound01.PlayOneShot(sound01.clip);
                        Destroy(hit.collider.gameObject);
                    }
                }

            }
        }
        else
        {
            dest = GameObject.Find(Oname);
            Destroy(dest);
        }
    }

    void IPunObservable.OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            // 自身のアバターのスタミナを送信する
            stream.SendNext(Oname);
        }
        else
        {
            // 他プレイヤーのアバターのスタミナを受信する
            Oname = (string)stream.ReceiveNext();
        }
    }
}