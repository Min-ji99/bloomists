using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Intro : MonoBehaviour
{
    public GameObject Factory;
    public GameObject question;
    public bool state = false;
    public AudioSource bgm;

    // Start is called before the first frame update
    void Start()
    {
        Factory.gameObject.SetActive(false);
        AudioSource bgm = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        touchClick();
    }

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

            if (hit.collider.gameObject.name == "seed")
            {
                GameObject.Find("All").transform.Find("Factory_OBJ").gameObject.SetActive(true);
                Invoke("soundPlay", 2f); // 배경음 재생
                state = true;
                Debug.Log(hit.collider.gameObject.name);
                //question.gameObject.SetActive(false);

            }

        }

    }

    void soundPlay()
    {
        bgm.Play();
    }
}
