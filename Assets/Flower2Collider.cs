using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flower2Collider : MonoBehaviour
{
    Flower2 f2;

    void Start()
    {
        f2 = GameObject.Find("Flower2").GetComponent<Flower2>();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.name == "Wide Roller (2)_f")
        {
            f2.state = false;  //roller 동작상태 꺼줌
            f2.flower2reach = true;  //roller 정지상태 켜줌
        }

    }
}
