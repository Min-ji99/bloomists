using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flower01 : MonoBehaviour
{
    public GameObject Plant;

    private float Dist;
    public bool state = false;
    //private Animator animator;

    Plant02 p2;
    Potion1 po1;




    void Start()
    {
        Plant.gameObject.SetActive(false);
        p2 = GameObject.Find("Plant2").GetComponent<Plant02>();
        po1 = GameObject.Find("04_liquid01").GetComponent<Potion1>();


        //animator = GameObject.Find("Plant2").transform.Find("plant02").GetComponent<Animator>();


    }

    void Update()
    {

        PlantAppear();


    }

    void PlantAppear()
    {

        if (p2.state == true)
        {
            if (po1.state == true)
            {
                //Invoke("Play", 3.0f);
                GameObject.Find("Flower1").transform.Find("flower01").gameObject.SetActive(true);
                //animator.SetBool("Click", false);
            }
        }
    }
}
