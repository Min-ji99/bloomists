using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit02 : MonoBehaviour
{
    public GameObject Plant;
    public GameObject final;

    private float Dist;
    public bool state = false;
    private float fruit2Dist;
    public bool fruit2reach = false;
    private bool isbloomed = false;

    Plant02 p2;
    color4 col4;

    public ParticleSystem blooming;

    void Start()
    {
        Plant.gameObject.SetActive(false);
        p2 = GameObject.Find("Plant2").GetComponent<Plant02>();
        col4 = GameObject.Find("10-4").GetComponent<color4>();

    }

    void Update()
    {
        fruit2Dist = Vector3.Distance(Plant.transform.position, final.transform.position);
        PlantAppear();       
    }

    void LateUpdate()
    {
       //print("fruit2Dist : " + fruit2Dist);
    }

    void PlantAppear()
    {


        if (p2.state == true)   //plant02 사라졌다면
        {
            if (col4.answer4 == true)  //물약4 눌렸다면 
            {
                //Invoke("Play", 3.0f);
                GameObject.Find("Fruit2").transform.Find("fruit02").gameObject.SetActive(true);     //fruit02 피어남
                Invoke("Particle", 0.0f); //파티클
                Invoke("Next", 3.0f);
       
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

        if (fruit2Dist < 2.04f)
        {
            state = false;  //roller 동작상태 꺼줌
            fruit2reach = true;  //roller 정지상태 켜줌
        }
    }
    
}
