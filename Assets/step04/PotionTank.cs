using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionTank : MonoBehaviour
{
    private Vector3 touchpos;
    private Animator animator;
    //public ParticleSystem snow;
    Potion4 potion4;
    Potion3 potion3;
    Potion2 potion2;
    Potion1 potion1;


    public bool pstate = false;


    // Use this for initialization 
    void Start()
    {
        animator = GetComponent<Animator>();
        potion4 = GameObject.Find("4_liquid04").GetComponent<Potion4>();
        potion3 = GameObject.Find("4_liquid03").GetComponent<Potion3>();
        potion2 = GameObject.Find("4_liquid02").GetComponent<Potion2>();
        potion1 = GameObject.Find("4_liquid01").GetComponent<Potion1>();


    }
    // Update is called once per frame 
    void Update()
    {
        //timer += Time.deltaTime;
        animator.SetBool("GoPotion", false);
        touchClick();
    }
    // 터치 시 오브젝트 확인 함수 
    void touchClick()
    {

        if (potion4.state == true|| potion3.state == true|| potion2.state == true|| potion1.state == true)  //포션이 클릭됐다면
        {
           
            Invoke("Play", 2f); //2초 뒤에
      
        }
        else
        {
            potion4.state = false;
            animator.SetBool("GoPotion", false);
        }


    }
    void Play()
    {
        animator.SetBool("GoPotion", true); //물약 기계 움직여
        pstate = true;  //기계 오면 plant2 사라지게

    }
    
}
