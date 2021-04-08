using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class snowtank : MonoBehaviour
{
    // bool isMove = false;
    private Vector3 touchpos;
    private Animator animator;
    public ParticleSystem snow;
    snow_start snowstart;
    float timer;

    public bool pstate = false;
    private bool IsDestroy_Ice = false;

    public AudioSource warning;


    // Use this for initialization 
    void Start()
    {
        animator = GetComponent<Animator>();
        snowstart = GameObject.Find("03_bluestick").GetComponent<snow_start>();
        AudioSource warning = GetComponent<AudioSource>();
    }
    // Update is called once per frame 
    void Update()
    {
        //timer += Time.deltaTime;
        animator.SetBool("snow", false);
        touchClick();
    }
    // 터치 시 오브젝트 확인 함수 
    void touchClick()
    {
        
        if (snowstart.state == true && IsDestroy_Ice == false)  //레버가 내려갔다면
        {
          
            //isMove = true;
            //animator.SetBool("snow", true);
            Invoke("Play", 2f); //2초뒤에 기계 움직임
            Invoke("Particle", 4f); //그 후 2초 뒤에 눈내림
            Invoke("Warn_sound", 2f);   
        }
        else
        {
            snowstart.state = false;
            animator.SetBool("snow", false);
        }

        // Debug.Log(hit.collider.gameObject.name);

        //}

        //   }

    }
    void Play()
    {
        animator.SetBool("snow", true); //꿀렁꿀렁 움직임

    }
    void Particle()
    {
        snow.Play();    //눈내림
        pstate = true;  //눈 파티클 실행됐으면 <Ice>
        Destroy(snow, 5f);
        IsDestroy_Ice = true;
    }

    void Warn_sound()
    {
        warning.Play();
    }
}
