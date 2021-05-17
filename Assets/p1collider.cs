using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class p1collider : MonoBehaviour
{
    Plant01 p1;

    void Start()
    {
        p1 = GameObject.Find("Plant1").GetComponent<Plant01>();
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
