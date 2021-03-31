using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Book : MonoBehaviour
{

    bool isMove = false;
    private Vector3 touchpos;
    private Animator animator;
    public bool state = false;
    public bool stateFactory = false;

    // Use this for initialization 
    void Start()
    {
        animator = GetComponent<Animator>();

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
        // 터치 입력이 들어올 경우
        if (Input.GetMouseButtonDown(0))
        {
            // 오브젝트 정보를 담을 변수 생성 
            RaycastHit hit;
            // 터치 좌표를 담는 변수 
            Ray touchray = Camera.main.ScreenPointToRay(Input.mousePosition);
            // 터치한 곳에 ray를 보냄 
            Physics.Raycast(touchray, out hit); // ray가 오브젝트에 부딪힐 경우 

            if(stateFactory == false)
            {
                if (hit.collider.gameObject.name == "Book_cover")
                {
                    if (isMove == false)
                    {
                        isMove = true;
                        animator.SetBool("Click", true);
                        //Invoke("touchClick", 5.0f);
                        state = true;
                        stateFactory = true;
                    }
                    else
                    {
                        isMove = false;
                        animator.SetBool("Click", false);
                        state = false;
                    }

                    Debug.Log(hit.collider.gameObject.name);
                }
            

            }

        }

    }
}
