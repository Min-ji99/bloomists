using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;
using System.Collections;

public class Seedposition : MonoBehaviour
{
    //
    //public PathCreator pathCreator;
    //public EndOfPathInstruction endOfPathInstruction;
    //public float speed = 5;
    //float distanceTravelled;
    //public bool path_stand = false;

    public GameObject seed;
    

    public GameObject Stand;
    public GameObject water;
    private float Dist;
    private float Dist2;
    private Animator animator;
    public bool state = false;
    public bool bud = false;
    public bool standOn = false;
   // public bool appear = false;
   // public bool isbloomed = false;
    public bool lightDetect = false;
    public bool growth = false;


    ////꽃 필때 파티클
    //public ParticleSystem bloom;
    //public AudioSource blooming;


    //lp판
    private float MDist;
    public GameObject MStart;
    public AudioSource Lp;
    public bool Music = false;


    stand_light light;
    rotate ro;
    watertank tank;
    Plant01 p1;
    Sensor sensor;

    void Start()
    {
        //animator = GetComponent<Animator>();
        animator = GameObject.Find("S_P").transform.Find("seed").GetComponent<Animator>();
        light = GameObject.Find("StandLight").GetComponent<stand_light>();
        ro = GameObject.Find("01").transform.Find("01_rotateplane").GetComponent<rotate>();
        tank = GameObject.Find("02").transform.Find("02_tank").GetComponent<watertank>();
        AudioSource Lp = GetComponent<AudioSource>();
        AudioSource blooming = GetComponent<AudioSource>();
        p1 = GameObject.Find("Plant1").GetComponent<Plant01>();
        sensor = GameObject.Find("ArdManager").GetComponent<Sensor>();


        //if (pathCreator != null)
        //{
        //    // Subscribed to the pathUpdated event so that we're notified if the path changes during the game
        //    pathCreator.pathUpdated += OnPathChanged;
        //}

    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("localPosition" + transform.localPosition);
        //Debug.Log("globalPosition" + transform.position);

        Dist = Vector3.Distance(seed.transform.position, Stand.transform.position);
        Dist2 = Vector3.Distance(seed.transform.position, water.transform.position);
        MDist = Vector3.Distance(seed.transform.position, MStart.transform.position);
        Play();

        //if(path_stand == false)
        //{
        //    if (pathCreator != null)
        //    {
        //        distanceTravelled += speed * Time.deltaTime;
        //        transform.position = pathCreator.path.GetPointAtDistance(distanceTravelled, endOfPathInstruction);
        //        //transform.rotation = pathCreator.path.GetRotationAtDistance(distanceTravelled, endOfPathInstruction);
        //    }
        //}

        //if(transform.position = new Vector3(7.00277f, -1.610846f, -0.8221116f))
        //{
        //    Destroy(stand_path);
        //    //stand_path.SetActive(false);
        //}
        //

    }



    void LateUpdate()
    {
        //Debug.Log("Dist : " + Dist);
        //Debug.Log("Dist2 : " + Dist2);
        //Debug.Log("MDist : " + MDist);

    }

    //void OnCollisionEnter(Collision collision)
    //{
    //    Debug.Log("collision");
    //    if (collision.collider.name == "WideBelt2r_1")
    //    {
    //        path = true;
    //        Debug.Log("path: " + path);
    //    }

    //    if (collision.collider.name == "Wide Roller_s1")
    //    {
    //        state = true;
    //        path_stand = true;

    //        //stand_path.SetActive(false);
    //        //if (sensor.lightDetect)   //★주석지워줘야함
    //        //{
    //        lightDetect = true;
    //        //}
    //    }

    //    else if (collision.collider.name == "WideBelt3r_m")
    //    {
    //        if (Music == false)
    //        {
    //            Lp.Play();
    //            Music = true;
    //        }
    //    }

    //    else if (collision.collider.name == "Wide Roller_s2")
    //    {
    //        if (ro.isMove == true)  //roller 동작상태라면
    //        {
    //            ro.isMove = false; //roller 동작상태 꺼줌
    //            appear = true; //step02에 도착하면 roller 정지상태 켜줌

    //            if (p1.extraWater == true) // 추가적인 물 받게되면
    //            {
    //                growth = true;
    //            }

    //            if (p1.WaterDetect == true)
    //            {
    //                Debug.Log("사라졋");
    //                Destroy(seed, 1.5f); //씨앗 오브젝트 사라짐
    //            }
    //        }
    //    }

    //}
    void Play()
    {

        Debug.Log("Dist : " + Dist);
        if (Dist < 0.1f)   // step01에 가까워지면
        {

            state = true; // rotateplane에 도착하면 roller 정지상태 켜줌
                          //Destroy(seed);
            seed.SetActive(false);
            standOn = true; //캔버스 뜨도록

            //if (sensor.lightDetect)       //빛 감지하면
            //{
                lightDetect = true;
           // }

        }

        if (lightDetect)
            {
               // Invoke("GoPlant", 1.0f); //1초뒤에 새싹 자라게
               // Invoke("particle", 0.0f); //파티클
            }
            //if (ro.isMove == true)  //roller 정지 상태 아니라면
            //{
           
            //    if (Dist2 < 0.244f)  //step02 에 다가오면
            //    {

       
            //        ro.isMove = false; //roller 동작상태 꺼줌
            //        appear = true; //step02에 도착하면 roller 정지상태 켜줌

            //        if (p1.extraWater == true) // 추가적인 물 받게되면
            //        {

            //            growth = true;
            //        }
            //        if (p1.WaterDetect == true)
            //        {
            //            Destroy(seed, 1.5f); //씨앗 오브젝트 사라짐
            //        }

            //    }

            //}

            //if(MDist < 0.45f)
            //{
            
            //    if (Music == false)
            //    {
            //        Lp.Play();
            //        Music = true;
            //    }
            //}
        

        }


    //void GoPlant()
    //{
    //    animator.SetBool("Go", true);   //애니메이션 재생
    //    bud = true; //새싹 true
    //    state = false; // roller 정지상태 꺼줌

    //}

    //void particle()
    //{
    //    if (isbloomed == false)
    //    {
    //        bloom.Play();
    //        Destroy(bloom, 2f);
    //        isbloomed = true;
    //        blooming.PlayOneShot(blooming.clip);
    //    }
    //}


}

