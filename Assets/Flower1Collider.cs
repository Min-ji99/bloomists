using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flower1Collider : MonoBehaviour
{
    Flower01 f1;

    void Start()
    {
        f1 = GameObject.Find("Flower1").GetComponent<Flower01>();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.name == "Wide Roller (2)_f")
        {
            f1.state = false;  //roller 동작상태 꺼줌
            f1.flower1reach = true;  //roller 정지상태 켜줌
        }

    }
}
