using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plant01 : MonoBehaviour
{
    public GameObject Plant;
    public GameObject icebox;
    private float Dist;
    //private Animator animator;
    public bool state = false;
    public bool appear = false;
    public bool bloom = false;

    //public bool bloom = false;

    Seedposition seedPos;
    watertank tank;

    public ParticleSystem blooming;



    void Start()
    {


        Plant.gameObject.SetActive(false);
        tank = GameObject.Find("02").transform.Find("02_tank").GetComponent<watertank>();
        seedPos = GameObject.Find("S_P").transform.Find("seed").GetComponent<Seedposition>();
        


    }

    // Update is called once per frame
    void Update()
    {

        Dist = Vector3.Distance(Plant.transform.position, icebox.transform.position);

        if (state == false) //false일동안 step02
        {
            PlantAppear();
        }

    }

    void LateUpdate()
    {
       // print("Dist : " + Dist);
    }



    void PlantAppear()
    {

        if (tank.watering == true) //물 애니메이션 재생되면
        {

            Play();
        }

        if (Dist < 0.245f) // step03 다가가면
        {
            Plant.gameObject.SetActive(false); //plant01 사라짐
            state = true; //plant01사라지면서 step03로
            appear = true; // roller 정지상태 켜줌
        }


    }
    void Play()
    {
        GameObject.Find("Plant1").transform.Find("plant01").gameObject.SetActive(true);    //plant01 생기면서 자라남
        Invoke("Particle", 0.8f); //파티클
        Invoke("GoPlant", 5.0f);    //5초 뒤에



    }

    void GoPlant()
    {
        seedPos.appear = false; //roller 정지상태 꺼줌
        bloom = true; //roller 동작상태 켜줌

    }

    void Particle()
    {
        blooming.Play();
        Destroy(blooming, 2f);
    }
}
