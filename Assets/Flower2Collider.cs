using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flower2Collider : MonoBehaviour
{
    Flower2 f2;
    public Rigidbody rb;
    test_way way;

    void Start()
    {
        f2 = GameObject.Find("Flower2").GetComponent<Flower2>();
        rb = GetComponent<Rigidbody>();
        way = GetComponent<test_way>();

    }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "roller5")
        {
            rb.isKinematic = false;
            way.enabled = false;
            f2.state = false;  //roller 동작상태 꺼줌
            f2.flower2reach = true;  //roller 정지상태 켜줌
        }

    }
}
