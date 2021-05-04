using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AfterIce : MonoBehaviour
{
    
    private Animator animator;

    public bool state_p2=false;
    public bool bloom = false;
    private bool particleOn = false;
    private bool soundOn = false;


    RemoveIce rIce;
    Plant01 p1;

    public ParticleSystem blooming;
    public AudioSource bloomingSound;

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

        if (rIce.state == true && soundOn==false) //얼음이 다 사라졌다면
        {
            bloomingSound.Play();
            soundOn = true;
            animator.SetBool("Click", true);    //plant02 자라남
            state_p2 = true;
            Invoke("Bloom", 2.0f);  //2초 뒤면
            Invoke("Particle", 0.0f); //파티클

        }
    }

    void Particle()
    {
        if (particleOn == false)
        {
            blooming.Play();
            Destroy(blooming, 2f);
            particleOn = true;
        }
    }

    void Bloom()
    {
        p1.appear = false;  //roller 정지상태 꺼줌
        bloom = true;   //roller 동작상태 켜줌
    }
}
