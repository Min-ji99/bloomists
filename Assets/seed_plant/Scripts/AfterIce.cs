using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AfterIce : MonoBehaviour
{
    
    private Animator animator;

    public bool iceBreaking=false;
    public bool bloom = false;
    private bool particleOn = false;
    private bool soundOn = false;


    RemoveIce rIce;
    Plant01 p1;
    Plant02 p2;
    test_way way;

    public ParticleSystem blooming;
    public AudioSource bloomingSound;

    // Use this for initialization 
    void Start()
    {
        animator = GetComponent<Animator>();
        rIce = GameObject.Find("ICE").transform.Find("03_ice").GetComponent<RemoveIce>();
        p1 = GameObject.Find("Plant1").GetComponent<Plant01>();
        p2 = GameObject.Find("Plant2").GetComponent<Plant02>();
        way = GetComponent<test_way>();
        way.enabled = false;
    }
    // Update is called once per frame 
    void Update()
    {
        animator.SetBool("Click", false);
        touchClick();
        if (iceBreaking)
        {
            way.enabled = true; //waypoint 실행
        }
    }

    void OnTriggerEnter(Collider collision)
    {
        Debug.Log(collision.gameObject.name);
        if (collision.gameObject.tag == "roller4")    //plant02 자라난 뒤 step04로 다가가면
        {
            p2.reach = true;    //roller 정지상태 켜줌
        }

    }

    // 터치 시 오브젝트 확인 함수 
    void touchClick()
    {

        if (rIce.state == true && soundOn==false) //얼음이 다 사라졌다면
        {
            bloomingSound.Play();
            soundOn = true;
            animator.SetBool("Click", true);    //plant02 자라남
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
            iceBreaking = true;
        }
    }

    void Bloom()
    {
        p1.appear = false;  //roller 정지상태 꺼줌
        bloom = true;   //roller 동작상태 켜줌
    }
}
