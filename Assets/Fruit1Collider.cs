using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit1Collider : MonoBehaviour
{
    Fruit01 f01;

    void Start()
    {
        f01 = GameObject.Find("Fruit1").GetComponent<Fruit01>();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.name == "Wide Roller (2)_f")
        {
            f01.state = false;  //roller 동작상태 꺼줌
            f01.fruit1reach = true;  //roller 정지상태 켜줌
        }

    }
}
