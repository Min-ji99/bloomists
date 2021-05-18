using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class p1collider : MonoBehaviour
{
    Plant01 p1;
    test_way way;

    void Start()
    {
        p1 = GameObject.Find("Plant1").GetComponent<Plant01>();
        way = GetComponent<test_way>();
        way.enabled = false;
    }

    void Update()
    {
        if (p1.bloom)
        {
            way.enabled = true;
        }
    }

    void OnTriggerEnter(Collider collision)
    {
        Debug.Log(collision.gameObject.name);
        if (collision.gameObject.tag == "roller3")
        {
            Destroy(gameObject);
            p1.disappear = true;
            p1.state = true; //plant01사라지면서 step03로
            p1.appear = true; // roller 정지상태 켜줌
        }

    }


}
