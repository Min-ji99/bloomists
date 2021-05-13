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

    private Animator animator;
    public bool lightDetect = false;
    public bool SeedOpened = false;
    public bool appear = false;
    public bool growth = false;
    private float Dist2;

    public PathCreator pathCreator;
    public EndOfPathInstruction endOfPathInstruction;
    public float speed = 5;
    float distanceTravelled;

    rotate ro;

    void Start()
    {

        ro = GameObject.Find("01").transform.Find("01_rotateplane").GetComponent<rotate>();
        seedPos = GameObject.Find("S_P").transform.Find("seed").GetComponent<Seedposition>();
        p1 = GameObject.Find("Plant1").GetComponent<Plant01>();

        animator = GameObject.Find("SeedOpen").transform.Find("seed_open").GetComponent<Animator>();

        if (pathCreator != null)
        {
            // Subscribed to the pathUpdated event so that we're notified if the path changes during the game
            pathCreator.pathUpdated += OnPathChanged;
        }
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetBool("Go", false);
        Dist2 = Vector3.Distance(seed.transform.position, water.transform.position);
        //Debug.Log("Dist2 : " + Dist2);

        //if (seedPos.state)
        //{
        //    Debug.Log("state");
        //    GameObject.Find("S_P").transform.Find("seed_open").gameObject.SetActive(true);   //씨앗 나타나게
        //}
        Play();

        
        if (pathCreator != null && ro.isMove)
        {
            distanceTravelled += speed * Time.deltaTime;
            transform.position = pathCreator.path.GetPointAtDistance(distanceTravelled, endOfPathInstruction);
            //transform.rotation = pathCreator.path.GetRotationAtDistance(distanceTravelled, endOfPathInstruction);
        }

    }

    void OnPathChanged()
    {
        distanceTravelled = pathCreator.path.GetClosestDistanceAlongPath(transform.position);
    }

    void Play()
    {

        //if (sensor.lightDetect)
        //{
        lightDetect = true;
        // }

        if (lightDetect) 
        {
            //Debug.Log("GoAnimation");

            animator.SetBool("Go", true);
            Invoke("OpenSeed", 2f);
           
        }
        
        if (ro.isMove == true)  //roller 정지 상태 아니라면
        {

            if (Dist2 < 0.216f)  //step02 에 다가오면
            {
                ro.isMove = false; //roller 동작상태 꺼줌
                appear = true; //step02에 도착하면 roller 정지상태 켜줌

                if (p1.extraWater == true) // 추가적인 물 받게되면
                {

                    growth = true;
                }

                //if (p1.WaterDetect == true)
                //{
                //    Debug.Log("Destroy");
                //    Destroy(seed, 1.5f); //씨앗 오브젝트 사라짐
                //}

            }
        
        }

    }

    void OpenSeed()
    {
        SeedOpened = true;
    }
}
