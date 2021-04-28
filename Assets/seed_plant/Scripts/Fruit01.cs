﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit01 : MonoBehaviour
{
    public GameObject Plant;
    public GameObject final;

    private float Dist;
    public bool state = false;
    private float fruit1Dist;
    public bool fruit1reach = false;
    private bool isbloomed = false;

    Plant02 p2;
    color3 col3;

    public ParticleSystem blooming;


    void Start()
    {
        Plant.gameObject.SetActive(false);
        p2 = GameObject.Find("Plant2").GetComponent<Plant02>();
        col3 = GameObject.Find("07-3").GetComponent<color3>();

    }

    void Update()
    {
        fruit1Dist = Vector3.Distance(Plant.transform.position, final.transform.position);
        PlantAppear();
    }

    void LateUpdate()
    {
        //print("fruit1Dist : " + fruit1Dist);
    }

    void PlantAppear()
    {

        if (p2.state == true)   //plant02 사라졌다면
        {
            if (col3.answer3 == true)  //물약2 눌렸다면 
            {
                
                GameObject.Find("Fruit1").transform.Find("fruit01").gameObject.SetActive(true);     //fruit01 피어남
                Invoke("Particle", 0.0f); //파티클
                Invoke("Next", 3.0f);   //5초 뒤에
               
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
        state = true;       //roller 동작상태 켜줌

        if (fruit1Dist < 2.38f)
        {
            state = false;  //roller 동작상태 꺼줌
            fruit1reach= true;  //roller 정지상태 켜줌
        }
    }
}
    

