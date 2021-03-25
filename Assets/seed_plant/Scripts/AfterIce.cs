using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AfterIce : MonoBehaviour
{
    
    private Animator animator;

    public bool state_p2=false;

    RemoveIce rIce;

    // Use this for initialization 
    void Start()
    {
        animator = GetComponent<Animator>();
        rIce = GameObject.Find("ICE").transform.Find("03_ice").GetComponent<RemoveIce>();
        
    }
    // Update is called once per frame 
    void Update()
    {
        animator.SetBool("Click", false);
        touchClick();
    }
    // 터치 시 오브젝트 확인 함수 
    void touchClick()
    {

        if (rIce.state == true)
        {

            animator.SetBool("Click", true);
            state_p2 = true;


        }
    }
}
