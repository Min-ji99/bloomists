using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotate : MonoBehaviour
{
    public bool isMove = false;

    
    private Animator animator;
    Seedposition Sp;
    

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
        BudGrow();
    }
    // 터치 시 오브젝트 확인 함수 
    void BudGrow()
    {
        if (Sp.bud==true)   //<Seedposition>에서 새싹이 자라면 
        {
            Invoke("Play", 2.0f);   //2초뒤에
        }
        
    }
    void Play()
    {
        animator.SetBool("Click", true);    //기계 돌아가는 애니메이션 재생
        isMove = true;  // roller 동작상태 켜줌
    }
}
