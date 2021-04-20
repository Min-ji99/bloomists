using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AfterIce : MonoBehaviour
{
    
    private Animator animator;

    public bool state_p2=false;
    public bool bloom = false;

    RemoveIce rIce;
    Plant01 p1;

    public ParticleSystem blooming;

    // Use this for initialization 
    void Start()
    {
        animator = GetComponent<Animator>();
        rIce = GameObject.Find("ICE").transform.Find("03_ice").GetComponent<RemoveIce>();
        p1 = GameObject.Find("Plant1").GetComponent<Plant01>();

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

        if (rIce.state == true) //얼음이 다 사라졌다면
        {

            animator.SetBool("Click", true);    //plant02 자라남
            state_p2 = true;
            Invoke("Bloom", 2.0f);  //2초 뒤면
            Invoke("Particle", 0.0f); //파티클


        }
    }

    void Particle()
    {
        blooming.Play();
        Destroy(blooming, 2f);
    }

    void Bloom()
    {
        p1.appear = false;  //roller 정지상태 꺼줌
        bloom = true;   //roller 동작상태 켜줌
    }
}
