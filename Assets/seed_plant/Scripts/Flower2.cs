using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flower2 : MonoBehaviour
{
    public GameObject Plant;

    private float Dist;
    public bool state = false;
    //private Animator animator;

    Plant02 p2;
    Potion3 po3;




    void Start()
    {
        Plant.gameObject.SetActive(false);
        p2 = GameObject.Find("Plant2").GetComponent<Plant02>();
        po3 = GameObject.Find("04_liquid03").GetComponent<Potion3>();


        //animator = GameObject.Find("Plant2").transform.Find("plant02").GetComponent<Animator>();


    }

    void Update()
    {

        PlantAppear();


    }

    void PlantAppear()
    {

        if (p2.state == true) {
            if (po3.state == true)
            {
                //Invoke("Play", 3.0f);
                GameObject.Find("Flower2").transform.Find("flower02").gameObject.SetActive(true);
                //animator.SetBool("Click", false);
            }
        } 
    }

        //if (rIce.state == true)
        //{
        //    animator.SetBool("Click", true);

        //}

    }

    //void Play()
    //{
    //    GameObject.Find("Fruit2").transform.Find("fruit02").gameObject.SetActive(true);
    //}

