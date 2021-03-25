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
        potion4 = GameObject.Find("04_liquid04").GetComponent<Potion4>();
        potion3 = GameObject.Find("04_liquid03").GetComponent<Potion3>();
        potion2 = GameObject.Find("04_liquid02").GetComponent<Potion2>();
        potion1 = GameObject.Find("04_liquid01").GetComponent<Potion1>();


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

        if (potion4.state == true|| potion3.state == true|| potion2.state == true|| potion1.state == true)
        {

            //isMove = true;
            //animator.SetBool("snow", true);
            Invoke("Play", 2f);
            //Invoke("Particle", 4f);


        }
        else
        {
            potion4.state = false;
            animator.SetBool("GoPotion", false);
        }

        // Debug.Log(hit.collider.gameObject.name);

        //}

        //   }

    }
    void Play()
    {
        animator.SetBool("GoPotion", true);
        pstate = true;

    }
    //void Particle()
    //{
    //    snow.Play();
    //    pstate = true;
    //}
}
