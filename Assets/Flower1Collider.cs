using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flower1Collider : MonoBehaviour
{
    Flower01 f1;
    public Rigidbody rb;
    test_way way;

    void Start()
    {
        f1 = GameObject.Find("Flower1").GetComponent<Flower01>();
        rb = GetComponent<Rigidbody>();
        way = GetComponent<test_way>();
    }

    void OnTriggerEnter(Collider collision)
    {
        Debug.Log(collision.gameObject.tag);
        if (collision.gameObject.tag == "roller5")
        {
            rb.isKinematic = false;
            way.enabled = false;
            f1.state = false;  //roller 동작상태 꺼줌
            f1.flower1reach = true;  //roller 정지상태 켜줌
            Debug.Log("f1 " + f1.flower1reach);
        }

    }
}
