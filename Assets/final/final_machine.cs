﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class final_machine : MonoBehaviour
{
    bool isMove = false;
    private Vector3 touchpos;
    private Animator animator;
    public bool isclosed = false;
    public ParticleSystem final_particle;
    Flower01 f1;

    // Use this for initialization 
    void Start()
    {
        animator = GetComponent<Animator>();
        f1 = GameObject.Find("Flower1").GetComponent<Flower01>();

    }
    // Update is called once per frame 
    void Update()
    {
        animator.SetBool("final", false);
        //Debug.Log("f1 : " + f1.stop);
        if(f1.stop = true) //trigger함수 작동했을 때
            touchClick();
    }
    // 터치 시 오브젝트 확인 함수 
    void touchClick()
    {
        // 터치 입력이 들어올 경우
        if (Input.GetMouseButtonDown(0))
        {
            // 오브젝트 정보를 담을 변수 생성 
            RaycastHit hit;
            // 터치 좌표를 담는 변수 
            Ray touchray = Camera.main.ScreenPointToRay(Input.mousePosition);
            // 터치한 곳에 ray를 보냄 
            Physics.Raycast(touchray, out hit); // ray가 오브젝트에 부딪힐 경우 

            if (hit.collider.gameObject.name == "Sphere001"|| hit.collider.gameObject.name == "Object003")
            {
                if (isMove == false)
                {
                    isMove = true;
                    //Invoke("machinePlay", 0.1f);
                    Invoke("bloom", 3f);
                    machinePlay();
                }
                else
                {
                    isMove = false;
                    animator.SetBool("final", false);
                }
                Debug.Log(hit.collider.gameObject.name);

            }

        }

    }

    void machinePlay()
    {
        animator.SetBool("final", true);
        isclosed = true;
    }

    void bloom()
    {
        final_particle.Play();
    }
}
