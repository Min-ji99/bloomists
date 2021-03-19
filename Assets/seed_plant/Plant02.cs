using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plant02 : MonoBehaviour
{
    public GameObject Plant;
    public GameObject potion;
    //private Animator animator;

    Plant01 p1;
    RemoveIce rIce;
    

    void Start()
    {
        Plant.gameObject.SetActive(false);
        p1 = GameObject.Find("plant01").GetComponent<Plant01>();
        rIce= GameObject.Find("03_ice").GetComponent<RemoveIce>();

        //animator = GameObject.Find("Plant2").transform.Find("plant02").GetComponent<Animator>();


    }

    void Update()
    {
        
        touchClick();
    }

    void touchClick()
    {


        if (p1.state == true)
        {
            Play();
            //animator.SetBool("Click", false);
        }
        //if (rIce.state == true)
        //{
        //    animator.SetBool("Click", true);

        //}

    }

    void Play()
    {
        GameObject.Find("Plant2").transform.Find("plant02").gameObject.SetActive(true);
    }
}
