using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit2Collider : MonoBehaviour
{
    Fruit02 f02;

    void Start()
    {
        f02 = GameObject.Find("Fruit2").GetComponent<Fruit02>();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.name == "Wide Roller (2)_f")
        {
            f02.state = false;  //roller 동작상태 꺼줌
            f02.fruit2reach = true;  //roller 정지상태 켜줌
        }

    }
}
