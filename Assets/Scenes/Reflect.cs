using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class reflect : MonoBehaviour
{
    // Start is called before the first frame update
    void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.name); // ÉçÉOÇï\é¶Ç∑ÇÈ
    }
}
