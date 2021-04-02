using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AfterWater : MonoBehaviour
{
    private Animator animator;
    public bool bloom = false;

    watertank tank;
    Plant01 p1;
    Seedposition Sp;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        
        tank = GameObject.Find("02").transform.Find("02_tank").GetComponent<watertank>();
        p1 = GameObject.Find("Plant1").GetComponent<Plant01>();
        Sp = GameObject.Find("S_P").transform.Find("seed").GetComponent<Seedposition>();
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetBool("Go", false);
        touchClick();
    }

    void touchClick()
    {
        if (tank.watering == true)
        {
            animator.SetBool("Go", true);
           
            
            Invoke("Bloom", 4.0f);
        }
    }

    void Bloom()
    {
        
        bloom = true;
        Sp.appear = false;
    }
}
