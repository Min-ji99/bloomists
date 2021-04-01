using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotate : MonoBehaviour
{
    public bool isMove = false;

    
    private Animator animator;
    Seedposition Sp;
    //public bool state = false;

    // Use this for initialization 
    void Start()
    {
        animator = GetComponent<Animator>();
        Sp = GameObject.Find("S_P").transform.Find("seed").GetComponent<Seedposition>();

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
        if (Sp.bud==true)
        {
            Invoke("Play", 2.0f);
        }
        
    }
    void Play()
    {
        animator.SetBool("Click", true);
        isMove = true;
    }
}
