using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flower01 : MonoBehaviour
{
    public GameObject Plant;
    public GameObject final;

    private float Dist;
    public bool state = false;
    private float flower1Dist;
    public bool flower1reach = false;
    private bool isbloomed = false;

    Plant02 p2;
    color1 col1;

    public ParticleSystem blooming;


    void Start()
    {
        Plant.gameObject.SetActive(false);
        p2 = GameObject.Find("Plant2").GetComponent<Plant02>();
        col1= GameObject.Find("10-1").GetComponent<color1>();

    }

    void Update()
    {
        flower1Dist = Vector3.Distance(Plant.transform.position, final.transform.position);
        PlantAppear();
    }

    void LateUpdate()
    {
        //print("flower1Dist : " + flower1Dist);
    }

    void PlantAppear()
    {

        if (p2.state == true)   //plant02 사라졌다면
        {
            if (col1.answer1 == true)  //물약1 눌렸다면 
            {
                //Invoke("Play", 3.0f);
                GameObject.Find("Flower1").transform.Find("flower01").gameObject.SetActive(true);       //flower01 피어남
                Invoke("Particle", 0.0f); //파티클
                Invoke("Next",3.0f);

            }
        }
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

    void Next()
    {
        p2.reach = false;   //roller 정지상태 꺼줌
        state = true;    //roller 동작상태 켜줌

        if (flower1Dist < 3.5f)
        {
            state = false;  //roller 동작상태 꺼줌
            flower1reach = true;  //roller 정지상태 켜줌
        }
    }
}
