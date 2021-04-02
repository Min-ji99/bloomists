using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plant02 : MonoBehaviour
{
    public GameObject Plant;
    public GameObject potion;
    private float Dist;
    public bool state = false;
    public bool reach = false;
    
    //private Animator animator;

    Plant01 p1;
   // RemoveIce rIce;
    PotionTank pt;
    
    

    void Start()
    {
        Plant.gameObject.SetActive(false);
        //p1 = GameObject.Find("plant01").GetComponent<Plant01>();
        p1 = GameObject.Find("Plant1").GetComponent<Plant01>();
        //rIce= GameObject.Find("03_ice").GetComponent<RemoveIce>();

        pt = GameObject.Find("04_tank").GetComponent<PotionTank>();

       


        //animator = GameObject.Find("Plant2").transform.Find("plant02").GetComponent<Animator>();


    }

    void Update()
    {
        if (state == false)
        {
            PlantAppear();
        }
        Dist = Vector3.Distance(Plant.transform.position, potion.transform.position);
       
    }

  

    void PlantAppear()
    {


        if (p1.state == true)   //plant01이 사라졌다면
        {
            
            Play();

            //animator.SetBool("Click", false);
        }
        //if (rIce.state == true)
        //{
        //    animator.SetBool("Click", true);

        //}
        if (pt.pstate == true) {

            Invoke("Disappear", 4.0f);

        }
    }

    //void LateUpdate()
    //{
    //    print("Dist : " + Dist);
    //}

    void Play()
    {
        GameObject.Find("Plant2").transform.Find("plant02").gameObject.SetActive(true);
        

        if (Dist < 0.365f)
        {

            reach = true;
        }
    }

    void Disappear()
    {
        Plant.gameObject.SetActive(false);
        state = true;
        //reach = false;
        p1.appear = false;
    }

}
