using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gear : MonoBehaviour
{
    private Vector3 touchpos;
    private Animator animator;
    //public ParticleSystem snow;
    snow_start snowstart;

    public bool pstate = false;

    // Use this for initialization 
    void Start()
    {
        animator = GetComponent<Animator>();
        snowstart = GameObject.Find("03_bluestick").GetComponent<snow_start>();


    }
    // Update is called once per frame 
    void Update()
    {

        animator.SetBool("Click", false);
        touchClick();
    }
    // 터치 시 오브젝트 확인 함수 
    void touchClick()
    {

        if (snowstart.state == true)
        {

            //Invoke("Play", 1f);
            Play();


        }
        else
        {
            snowstart.state = false;
            animator.SetBool("Click", false);
        }



    }
    void Play()
    {
        animator.SetBool("Click", true);

    }
}
