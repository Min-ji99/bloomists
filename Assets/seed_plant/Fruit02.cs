using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit02 : MonoBehaviour
{
    public GameObject Plant;
    
    private float Dist;
    public bool state = false;
    //private Animator animator;

    Plant02 p2;
    


    void Start()
    {
        Plant.gameObject.SetActive(false);
        p2 = GameObject.Find("Plant2").GetComponent<Plant02>();
        

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
            //Invoke("Play", 3.0f);
            GameObject.Find("Fruit2").transform.Find("fruit02").gameObject.SetActive(true);
            //animator.SetBool("Click", false);
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
}
