using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveIce : MonoBehaviour
{
    public GameObject ice1;
    public GameObject ice2;
    public GameObject ice3;
    public GameObject ice4;
    public GameObject ice5;
    public bool state = false;
    private Vector3 touchpos;
    // private Animator animator;
    public ParticleSystem ib1;
    public ParticleSystem ib2;
    public ParticleSystem ib3;
    public ParticleSystem ib4;
    public ParticleSystem ib5;

    public int ices=5;

    Ice i;

    public AudioSource ice_break;

    void Start()
    {
        //animator = GetComponent<Animator>();
        i = GameObject.Find("ICE").GetComponent<Ice>();
        AudioSource ice_break = GetComponent<AudioSource>();
    }

    void Update()
    {
        //animator.SetBool("Click", false);

        if (i.istate == true)   //얼음이 생겼다면
        {
            //animator.SetBool("Click", true);
            touchClick();
        }
       
    }

    void touchClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // 오브젝트 정보를 담을 변수 생성 
            RaycastHit hit;
            // 터치 좌표를 담는 변수 
            Ray touchray = Camera.main.ScreenPointToRay(Input.mousePosition);
            // 터치한 곳에 ray를 보냄 
            Physics.Raycast(touchray, out hit); // ray가 오브젝트에 부딪힐 경우 

            if (hit.collider.gameObject.name == "ice01")    //얼음1 클릭시
            {
               ice1.gameObject.SetActive(false);    //얼음1 사라져
                ice_break.Play();
                ib1.Play();
                ices--;                         //하나씩 사라지게
            }
            else if (hit.collider.gameObject.name == "ice02")
            {
                ice2.gameObject.SetActive(false);
                ib2.Play();
                ice_break.Play();
                ices--;
            }
            else if (hit.collider.gameObject.name == "ice03")
            {
                ice3.gameObject.SetActive(false);
                ib3.Play();
                ice_break.Play();
                ices--;
            }
            else if (hit.collider.gameObject.name == "ice04")
            {
                ice4.gameObject.SetActive(false);
                ib4.Play();
                ice_break.Play();
                ices--;
            }
            else if (hit.collider.gameObject.name == "ice05")
            {
                ice5.gameObject.SetActive(false);
                ib5.Play();
                ice_break.Play();
                ices--;

            }

            if (ices == 0)  //5개가 모두 사라지면
            {
                state = true;   // 얼음이 다 사라졌다면 <AfterIce>
                ice_break.enabled = false;
            }

        }


    }
}
