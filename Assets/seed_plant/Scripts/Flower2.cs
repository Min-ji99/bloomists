using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flower2 : MonoBehaviour
{
    public GameObject Plant;
    public GameObject final;

    private float Dist;
    public bool state = false;
    private float flower2Dist;
    public bool flower2reach = false;
    private bool isbloomed = false;
    private bool soundOn = false;
    public bool potionDetect = false;

    Plant02 p2;
    color2 col2;
    Sensor sensor;

    public ParticleSystem blooming;
    public AudioSource bloomingSound;


    void Start()
    {
        Plant.gameObject.SetActive(false);
        p2 = GameObject.Find("Plant2").GetComponent<Plant02>();
        col2 = GameObject.Find("10-2").GetComponent<color2>();
        sensor = GameObject.Find("ArdManager").GetComponent<Sensor>();

    }

    void Update()
    {
        flower2Dist = Vector3.Distance(Plant.transform.position, final.transform.position);
        PlantAppear();
        if (sensor.potionDetect)
        {
            potionDetect = true;
        }
    }

    void LateUpdate()
    {
        //print("flower2Dist : " + flower2Dist);
    }

    void PlantAppear()
    {

        if (p2.state == true) {     //plant02 사라졌다면
            if (col2.answer2 == true )  //물약3 눌렸다면 
            {
                if (potionDetect){
                    GameObject.Find("Flower2").transform.Find("flower02").gameObject.SetActive(true);       //flower02 피어남
                    if (soundOn == false)
                    {
                        bloomingSound.Play();
                        soundOn = true;
                    }
                    Invoke("Particle", 0.0f); //파티클
                    Invoke("Next", 3.0f);
                }
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

        if (flower2Dist < 2.574f)
        {
            state = false;  //roller 동작상태 꺼줌
            flower2reach = true;  //roller 정지상태 켜줌
        }
    }
}

    
