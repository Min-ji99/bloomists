﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class snowtank02 : MonoBehaviour
{
    bool isMove = false;
    private Vector3 touchpos;
    private Animator animator;
    public ParticleSystem smoke;

    public AudioSource snowtank;

    // Use this for initialization 
    void Start()
    {
        animator = GetComponent<Animator>();
        AudioSource snowtank = GetComponent<AudioSource>();

    }
    // Update is called once per frame 
    void Update()
    {
        //animator.SetBool("Snow02", false);
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

            if (hit.collider.gameObject.name == "Cylinder310" ||
                hit.collider.gameObject.name == "Cylinder311" ||
                hit.collider.gameObject.name == "Sphere029")
            {
                if (isMove == false)
                {
                    Invoke("touchClick", 5.0f);
                    isMove = true;
                    // animator.SetBool("Snow02", true);
                    Invoke("play", 1.0f);
                    Invoke("tankSound", 1.5f);
                    
                }
                else
                {
                    isMove = false;
                    //animator.SetBool("Snow02", false);
                }

                Debug.Log(hit.collider.gameObject.name);

            }

        }

    }
   void play()
    {
        smoke.Play();
        
    }

    void tankSound()
    {
        snowtank.Play();
    }
}
