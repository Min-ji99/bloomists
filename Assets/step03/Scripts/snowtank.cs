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
   

    // Use this for initialization 
    void Start()
    {
        animator = GetComponent<Animator>();
        snowstart = GameObject.Find("03_bluestick").GetComponent<snow_start>();
        

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
        
        if (snowstart.state == true)
        {
          
            //isMove = true;
            //animator.SetBool("snow", true);
            Invoke("Play", 4f);
            Invoke("Particle", 6f);
         
           
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
        animator.SetBool("snow", true);

    }
    void Particle()
    {
        snow.Play();
        pstate = true;
    }
}
