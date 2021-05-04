using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour
{
    bool isMove = false;
    private Vector3 touchpos;
    private Animator animator;

    public AudioSource start_lever;
    public bool leverOn = false;

    public ParticleSystem leverParticle;
    public AudioSource particleSound;
    public bool particleOn = false;

    // Use this for initialization 
    void Start()
    {
        animator = GetComponent<Animator>();
        AudioSource start_lever = GetComponent<AudioSource>();

    }
    // Update is called once per frame 
    void Update()
    {
        animator.SetBool("Lever", false);
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

            if (hit.collider.gameObject.name == "Cylinder275" || hit.collider.gameObject.name == "Sphere041")
            {
                if (isMove == false)
                {
                    isMove = true;
                    Invoke("lever_anim", 1f);
                    Invoke("Particle", 3f); //파티클

                    //Invoke("touchClick", 5.0f);
                }
                else
                {
                    isMove = false;
                    animator.SetBool("Lever", false);
                }

                Debug.Log(hit.collider.gameObject.name);

            }

        }

    }

    void lever_anim()
    {
        animator.SetBool("Lever", true);
        if (leverOn == false)
        {
            start_lever.Play();
            leverOn = true;
        }
    }

    void Particle()
    {
        if (particleOn == false)
        {
            leverParticle.Play();
            particleSound.Play();
            Destroy(leverParticle, 2f);
            particleOn = true;
        }
    }
}