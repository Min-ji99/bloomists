using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plant01 : MonoBehaviour
{
    public GameObject Seed;
    public GameObject Plant;
    public GameObject icebox;
    private float Dist;
    //private Animator animator;
    public bool state = false;
    public bool appear = false;
    public bool bloom = false;
    private bool isbloomed = false;
    public bool extraWater = false;
    public bool disappear = false;
    public bool soundOn = false;
    public bool WaterDetect = false;

    //public bool bloom = false;

    Seedposition seedPos;
    watertank tank;
    Sensor sensor;

    public ParticleSystem blooming;
    public AudioSource bloomingSound;



    void Start()
    {

        //GameObject.Find("Plant1").transform.Find("plant01").gameObject.SetActive(false);
        Plant.gameObject.SetActive(false);
        tank = GameObject.Find("02").transform.Find("02_tank").GetComponent<watertank>();
        seedPos = GameObject.Find("S_P").transform.Find("seed").GetComponent<Seedposition>();
        sensor = GameObject.Find("ArdManager").GetComponent<Sensor>();


    }

    // Update is called once per frame
    void Update()
    {
        if (disappear == false)
        {
            Dist = Vector3.Distance(Plant.transform.position, icebox.transform.position);

            if (state == false) //false일동안 step02
            {
                //if (sensor.waterDetect)   //★주석없애야함
                //{
                WaterDetect = true;
                //}
                PlantAppear();
            }
        }
    }

    void LateUpdate()
    {
        // print("Dist : " + Dist);
    }


    void PlantAppear()
    {

        if (tank.watering == true) //물 애니메이션 재생되고
        {
            extraWater = true;      //(임시)추가로 물
            if (WaterDetect)
                Invoke("Play", 1.5f);
        }

        //if (Dist < 0.245f) // step03 다가가면
        //{
        //    //Plant.gameObject.SetActive(false); //plant01 사라짐

        //    Destroy(Plant);
        //    disappear = true;
        //    state = true; //plant01사라지면서 step03로
        //    appear = true; // roller 정지상태 켜줌
        //}


    }

    void Play()
    {
        if (disappear == false && soundOn == false)
        {
            bloomingSound.Play();
            GameObject.Find("Plant1").transform.Find("plant01").gameObject.SetActive(true);    //plant01 생기면서 자라남
            Destroy(Seed);
            Invoke("Particle", 0.8f); //파티클
            Invoke("GoPlant", 5.0f);    //5초 뒤에  
            soundOn = true;
        }
    }

    void GoPlant()
    {
        seedPos.appear = false; //roller 정지상태 꺼줌
        bloom = true; //roller 동작상태 켜줌

    }

    void Particle()
    {
        if (isbloomed == false)
        {
            blooming.Play();
            Destroy(blooming, 2f);
            isbloomed = true;
        }
    }
}