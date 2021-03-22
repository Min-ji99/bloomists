using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionTank : MonoBehaviour
{
    private Vector3 touchpos;
    private Animator animator;
    //public ParticleSystem snow;
    Potion4 potion4;
    

    public bool pstate = false;


    // Use this for initialization 
    void Start()
    {
        animator = GetComponent<Animator>();
        potion4 = GameObject.Find("04_liquid04").GetComponent<Potion4>();


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

        if (potion4.state == true)
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
