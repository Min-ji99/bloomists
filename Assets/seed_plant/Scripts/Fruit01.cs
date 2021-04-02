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




    void Start()
    {
        Plant.gameObject.SetActive(false);
        p2 = GameObject.Find("Plant2").GetComponent<Plant02>();
        po2 = GameObject.Find("04_liquid02").GetComponent<Potion2>();


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
            if (po2.state == true)
            {
                //Invoke("Play", 3.0f);
                GameObject.Find("Fruit1").transform.Find("fruit01").gameObject.SetActive(true);
                Invoke("Next", 5.0f);
                //animator.SetBool("Click", false);
            }
        }
    }

    void Next()
    {
        p2.reach = false;
        state = true;

    }
}
    

