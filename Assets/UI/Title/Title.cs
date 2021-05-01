using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Title : MonoBehaviour
{
    private Animator animator;
    bool isMove = false;
    
    void Start()
    {
        animator = GetComponent<Animator>();
        animator.SetBool("Title", false);   //애니메이션 작동하지마
    }

    // Update is called once per frame
    void Update()
    {
        Invoke("TitleSize", 3f);
    }

    void TitleSize()
    {
        if (isMove == false)
        {
            animator.SetBool("Title", true);    //애니메이션 재생
            isMove = true;
        }

        else
        {
            isMove = false;
            animator.SetBool("Title", false);
        }

    }
}
