using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class watertank : MonoBehaviour
{
    bool isMove = false;
    private Vector3 touchpos;
    private Animator animator;
    public ParticleSystem water;

    public bool watering = false;

    public AudioSource shower;



    // Use this for initialization 
    void Start()
    {
        animator = GetComponent<Animator>();
        AudioSource shower = GetComponent<AudioSource>();
    }
    // Update is called once per frame 
    void Update()
    {
        animator.SetBool("water", false);   //애니메이션 작동하지마
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

            if (hit.collider.gameObject.name == "02_tank" || hit.collider.gameObject.name == "Torus013")    //핸들 누르면
            {
                if (isMove == false)
                {
                    isMove = true;
                    animator.SetBool("water", true);    //애니메이션 재생

                    Invoke("Particle", 10.0f);  //10초뒤에
                    
                    //Invoke("touchClick", 5.0f);
                }
                else
                {
                    isMove = false;
                    animator.SetBool("water", false);
                }

                Debug.Log(hit.collider.gameObject.name);

            }

        }

    }

    void Particle()
    {
        water.Play();   //파티클 재생
        watering = true;    //물 재생되면 식물 자라나게
        shower.Play();
    }
}
