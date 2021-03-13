using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seed : MonoBehaviour
{
    public GameObject sd;

    void Start()
    {
        sd.gameObject.SetActive(false);
    }

    void Update()
    {
        touchClick();
    }

    void touchClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // 오브젝트 정보를 담을 변수 생성 
            RaycastHit hit;
            // 터치 좌표를 담는 변수 
            Ray touchray = Camera.main.ScreenPointToRay(Input.mousePosition);
            // 터치한 곳에 ray를 보냄 
            Physics.Raycast(touchray, out hit); // ray가 오브젝트에 부딪힐 경우 

            if (hit.collider.gameObject.name == "Cylinder275" || hit.collider.gameObject.name == "Sphere041")
            {
                Invoke("Play", 2f);
            }
        }
    }

    void Play()
    {
        GameObject.Find("GameObject (1)").transform.Find("seed").gameObject.SetActive(true);
    }
}
