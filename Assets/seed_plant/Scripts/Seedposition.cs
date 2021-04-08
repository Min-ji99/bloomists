using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seedposition : MonoBehaviour
{

    public GameObject seed;
    public GameObject Stand;
    public GameObject water;
    private float Dist;
    private float Dist2;
    private Animator animator;
    public bool state = false;
    public bool bud = false;
    public bool state2 = false;
    public bool appear = false;

    //lp판
    private float MDist;
    public GameObject MStart;
    public AudioSource Lp;
    public bool Music = false;

    Light light;
    rotate ro;
    watertank tank;


    // Start is called before the first frame update
    void Start()
    {
        //animator = GetComponent<Animator>();
        animator = GameObject.Find("S_P").transform.Find("seed").GetComponent<Animator>();
        light = GameObject.Find("StandLight").GetComponent<Light>();
        ro = GameObject.Find("01").transform.Find("01_rotateplane").GetComponent<rotate>();
        tank = GameObject.Find("02").transform.Find("02_tank").GetComponent<watertank>();
        AudioSource Lp = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        Dist = Vector3.Distance(seed.transform.position, Stand.transform.position);
        Dist2 = Vector3.Distance(seed.transform.position, water.transform.position);
        MDist = Vector3.Distance(seed.transform.position, MStart.transform.position);
        Play();

    }

    void LateUpdate()
    {
        //print("Dist : " + Dist);
        //Debug.Log("Dist2 : " + Dist2);
    }

    void Play()
    {


        if (Dist < 0.16f)   // step01에 가까워지면
        {

            state = true; // rotateplane에 도착하면 roller 정지상태 켜줌

        }
        if (light.state == true) //빛이 나타나면
        {
            Invoke("GoPlant", 1.0f); //1초뒤에 새싹 자라게
        }
        if (ro.isMove == true)  //roller 정지 상태 아니라면
        {
            //Debug.Log("Dist2 : " + Dist2);

            if (Dist2 < 0.15f)  //step02 에 다가오면
            {

       
                ro.isMove = false; //roller 동작상태 꺼줌
                appear = true; //step02에 도착하면 roller 정지상태 켜줌

                if (tank.watering == true) //물 애니메이션 재생되면
                {
                    seed.gameObject.SetActive(false); //씨앗 오브젝트 사라짐
                }

            }

        }

        if(MDist < 0.342f)
        {
            Debug.Log("MDist : " + MDist);
            if (Music == false)
            {
                Lp.Play();
                Music = true;
            }
        }
        

    }


    void GoPlant()
    {
        animator.SetBool("Go", true);   //애니메이션 재생
        bud = true; //새싹 true
        state = false; // roller 정지상태 꺼줌

    }
}

