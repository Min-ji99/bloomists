using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;
using System.Collections;

public class seedOpen : MonoBehaviour
{
    public GameObject seed;
    public GameObject water;

    Seedposition seedPos;
    Plant01 p1;
    test_way way;
    public Sensor sensor;

    private Animator animator;
    public bool lightDetect = false;
    public bool SeedOpened = false;
    public bool appear = false;
    public bool stop = false;
    public bool isbloomed = false;

    private float Dist2;
    private float MDist;

    //패쓰
    //public PathCreator pathCreator;
    //public EndOfPathInstruction endOfPathInstruction;
    //public float speed = 5;
    //float distanceTravelled;

    //꽃 필때 파티클
    public ParticleSystem bloom;
    public AudioSource blooming;

    public AudioSource Lp;
    public bool Music = false;
    public GameObject MStart;

    rotate ro;  // 1단계 회전판
    watertank tank;

    void Start()
    {
        way = GetComponent<test_way>();
        way.enabled = false;

        ro = GameObject.Find("01").transform.Find("01_rotateplane").GetComponent<rotate>();
        seedPos = GameObject.Find("S_P").transform.Find("seed").GetComponent<Seedposition>();
        p1 = GameObject.Find("Plant1").GetComponent<Plant01>();
        tank = GameObject.Find("02").transform.Find("02_tank").GetComponent<watertank>();

        animator = GameObject.Find("SeedOpen").transform.Find("seed_open").GetComponent<Animator>();

        //if (pathCreator != null)
        //{
        //    // Subscribed to the pathUpdated event so that we're notified if the path changes during the game
        //    pathCreator.pathUpdated += OnPathChanged;
        //}
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetBool("Go", false);

        //Dist2 = Vector3.Distance(seed.transform.position, water.transform.position);
        //MDist = Vector3.Distance(seed.transform.position, MStart.transform.position);
        //Debug.Log("Dist2 : " + Dist2);
        //Debug.Log("MDist : " + MDist);

        //if (seedPos.state)
        //{
        //    Debug.Log("state");
        //    GameObject.Find("S_P").transform.Find("seed_open").gameObject.SetActive(true);   //씨앗 나타나게
        //}
        Play();
        //Debug.Log(wayPointWater.seedend);

        //if (pathCreator != null && ro.isMove)
        //{
        //    distanceTravelled += speed * Time.deltaTime;
        //    transform.position = pathCreator.path.GetPointAtDistance(distanceTravelled, endOfPathInstruction);
        //    //transform.rotation = pathCreator.path.GetRotationAtDistance(distanceTravelled, endOfPathInstruction);
        //}

    }

    //void OnPathChanged()
    //{
    //    distanceTravelled = pathCreator.path.GetClosestDistanceAlongPath(transform.position);
    //}

    void Play()
    {

        if (sensor.lightDetect)   //★주석없애야함
        {
            lightDetect = true;
        }

        if (lightDetect) 
        {
            //Debug.Log("GoAnimation");

            animator.SetBool("Go", true);
            PlayEffect();

            Invoke("OpenSeed", 2f);
            //Invoke("PlayLP", 15f);


        }
       
        //if (ro.isMove == true && wayPointWater.seedend)  //roller 동작상태이고 
        //{
        //    Debug.Log(wayPointWater.seedend);

        //    ro.isMove = false; //roller 동작상태 꺼줌
        //    appear = true; //step02에 도착하면 roller 정지상태 켜줌

        //    if (p1.extraWater == true) // 추가적인 물 받게되면
        //    {

        //        growth = true;
        //    }

        //    //if (p1.WaterDetect == true)
        //    //{
        //    //    Debug.Log("Destroy");
        //    //    Destroy(seed, 1.5f); //씨앗 오브젝트 사라짐
        //    //}
        //}
        
        

    }

    void OpenSeed()
    {
        SeedOpened = true;
        seedPos.state = false;

        way.enabled = true;
    }

    void PlayEffect()
    {
        if (isbloomed == false)
        {
            bloom.Play();
            Destroy(bloom, 2f);
            isbloomed = true;
            blooming.PlayOneShot(blooming.clip);
        }
    }
    void OnTriggerEnter(Collider collision)
    {

        Debug.Log(collision.gameObject.name);

        if (collision.gameObject.tag == "music")
        {
            if (Music == false)
            {
                Lp.Play();
                Music = true;
            }
        }
        if (collision.gameObject.tag == "roller2")
        {
            SeedOpened = false; //roller 동작상태 꺼줌
            appear = true; //step02에 도착하면 roller 정지상태 켜줌
            stop = true;
            //if (p1.extraWater == true) // 추가적인 물 받게되면
            //{
            //    growth = true;
            //}

            //if (tank.watering == true && p1.WaterDetect == true)
            //{
            //    Debug.Log("사라졋");
            //    Destroy(seed, 1.5f); //씨앗 오브젝트 사라짐
            //}
        }
    }
    //void PlayLP()
    //{
    //    if (Music == false)
    //    {
    //        Lp.Play();
    //        Music = true;
    //    }
    //}
    /*void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.name);
        if (collision.collider.name == "WideBelt3r_m")
        {
            if (Music == false)
            {
                Lp.Play();
                Music = true;
            }
        }

        else if (collision.collider.name == "Wide Roller_s2")
        {
            if (SeedOpened == true)  //roller 동작상태라면
            {
                SeedOpened = false; //roller 동작상태 꺼줌
                appear = true; //step02에 도착하면 roller 정지상태 켜줌

                //if (p1.extraWater == true) // 추가적인 물 받게되면
                //{
                //    growth = true;
                //}

                //if (tank.watering == true && p1.WaterDetect == true)
                //{
                //    Debug.Log("사라졋");
                //    Destroy(seed, 1.5f); //씨앗 오브젝트 사라짐
                //}
            }
        }
    }*/

}
