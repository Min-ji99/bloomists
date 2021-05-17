﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit2Collider : MonoBehaviour
{
    Fruit02 f02;
    public Rigidbody rb;
    test_way way;

    void Start()
    {
        f02 = GameObject.Find("Fruit2").GetComponent<Fruit02>();
        rb = GetComponent<Rigidbody>();
        way = GetComponent<test_way>();
    }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "roller5")
        {
            rb.isKinematic = false;
            way.enabled = false;
            f02.state = false;  //roller 동작상태 꺼줌
            f02.fruit2reach = true;  //roller 정지상태 켜줌
        }

    }
}
