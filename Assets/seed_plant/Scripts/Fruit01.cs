using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit01 : MonoBehaviour
{
    public GameObject Plant;

    private float Dist;
    public bool state = false;
    //private Animator animator;

    Plant02 p2;
    Potion2 po2;

    public ParticleSystem blooming;


    void Start()
    {
        Plant.gameObject.SetActive(false);
        p2 = GameObject.Find("Plant2").GetComponent<Plant02>();
        po2 = GameObject.Find("4_liquid02").GetComponent<Potion2>();


        //animator = GameObject.Find("Plant2").transform.Find("plant02").GetComponent<Animator>();


    }

    void Update()
    {

        PlantAppear();


    }

    void PlantAppear()
    {

        if (p2.state == true)   //plant02 사라졌다면
        {
            if (po2.state == true)  //물약2 눌렸다면 
            {
                
                GameObject.Find("Fruit1").transform.Find("fruit01").gameObject.SetActive(true);     //fruit01 피어남
                Invoke("Particle", 0.0f); //파티클
                Invoke("Next", 3.0f);   //5초 뒤에
               
            }
        }
    }

    void Particle()
    {
        blooming.Play();
        Destroy(blooming, 2f);
    }


    void Next()
    {
        p2.reach = false;   //roller 정지상태 꺼줌
        state = true;       //roller 동작상태 켜줌

    }
}
    

