using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seedposition : MonoBehaviour
{
    public GameObject seed;
    public GameObject Stand;
    public GameObject water;
    private float Dist;
    private float Dist2;
    private Animator animator;
    public bool state = false;
    public bool bud = false;
    public bool state2 = false;
    public bool appear = false;

    Light light;
    rotate ro;


    // Start is called before the first frame update
    void Start()
    {
        //animator = GetComponent<Animator>();
        animator = GameObject.Find("S_P").transform.Find("seed").GetComponent<Animator>();
        light = GameObject.Find("StandLight").GetComponent<Light>();
        ro= GameObject.Find("01").transform.Find("01_rotateplane").GetComponent<rotate>();
    }

    // Update is called once per frame
    void Update()
    {
        Dist = Vector3.Distance(seed.transform.position, Stand.transform.position);
        Dist2 = Vector3.Distance(seed.transform.position, water.transform.position);
        Play();
        
    }

    void LateUpdate()
    {
       //print("Dist : " + Dist);
        //Debug.Log("Dist2 : " + Dist2);
    }

    void Play()
    {

        
        if (Dist < 0.16f)
        {
           
            state = true;
         
        }
        if (light.state == true)
        {
            Invoke("GoPlant", 1.0f);
        }
        if (ro.isMove==true)
        {
            //Debug.Log("Dist2 : " + Dist2);
            if (Dist2 < 0.15f)
            {
                
                seed.gameObject.SetActive(false);
                state2 = true;
                ro.isMove = false;
                appear = true;
               
            }

        }
    }

    //void Next()
    //{
    //    if (Dist2 < 0.15f)
    //    {
    //        Debug.Log("water");
    //        //seed.gameObject.SetActive(false);
    //        state2 = true;
    //    }
    //}

    void GoPlant()
    {
        animator.SetBool("Go", true);
        bud = true;
        state = false;
        
    }
}

