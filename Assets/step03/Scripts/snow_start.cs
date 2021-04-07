using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class snow_start : MonoBehaviour
{
    bool isMove = false;
    private Vector3 touchpos;
    private Animator animator;
    public bool state = false;

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

            if (hit.collider.gameObject.name == "Cylinder310" ||
                hit.collider.gameObject.name == "Cylinder311" ||
                hit.collider.gameObject.name == "Sphere029")           //파란 레버 누르면
            {
                if (isMove == false)
                {
                    isMove = true;
                    animator.SetBool("Click", true);    //레버 내려감
                    //Invoke("touchClick", 5.0f);
                    state = true;   //레버 내려간 상태-> <Gear> -> <snowtank02> -> <snowtank>
                }
                else
                {
                    isMove = false;
                    animator.SetBool("Click", false);
                    state = false;
                }

               // Debug.Log(hit.collider.gameObject.name);

            }

        }

    }
}
