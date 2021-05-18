using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit1Collider : MonoBehaviour
{
    Fruit01 f01;
    public Rigidbody rb;
    public test_way way;

    void Start()
    {
        f01 = GameObject.Find("Fruit1").GetComponent<Fruit01>();
        //srb = GetComponent<Rigidbody>();
        //way = GetComponent<test_way>();
    }

    void OnTriggerEnter(Collider collision)
    {
        Debug.Log(collision.gameObject.tag);
        if (collision.gameObject.tag == "roller5")
        {
            rb.isKinematic = false;
            way.enabled = false;
            f01.state = false;  //roller 동작상태 꺼줌
            f01.fruit1reach = true;  //roller 정지상태 켜줌
        }

    }
}
