using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Canvas_UI : MonoBehaviour
{
    bool isMove = false;
    bool answered = false;

    public GameObject seedmachine;
    public GameObject stand;
    public GameObject musicLP;
    public GameObject water;
    public GameObject waterPot;
    public GameObject snow_joystick;
    public GameObject ice;
    public GameObject potion;
    public GameObject colorAsk;
    public GameObject color01;
    public GameObject color02;
    public GameObject color03;
    public GameObject color04;
    public GameObject spoid;
    public GameObject final_comment01;
    public GameObject final_comment02;
    public GameObject final_comment03;
    public GameObject final_comment04;
    public GameObject final_comment05;

    private bool IsDestroy1 = false;
    private bool IsDestroy2 = false;
    private bool IsDestroy2_1 = false;
    private bool IsDestroy3 = false;
    private bool IsDestroy4 = false;
    private bool IsDestroy5 = false;
    private bool IsDestroy6 = false;
    private bool IsDestroy7 = false;
    private bool IsDestroy7_1 = false;
    private bool IsDestroy7_2 = false;
    private bool IsDestroy7_3 = false;
    private bool IsDestroy7_4 = false;

    //색상 선택 
    public bool answer1 = false;
    public bool answer2 = false;
    public bool answer3 = false;
    public bool answer4 = false;


    Intro intro;
    Seedposition Light;
    Plant01 p1;
    //Ice iceball;
    snowtank tank;
    Plant02 p2;
    

    // Start is called before the first frame update
    void Start()
    {
        seedmachine.gameObject.SetActive(false);
        stand.gameObject.SetActive(false);
        musicLP.gameObject.SetActive(false);
        water.gameObject.SetActive(false);
        waterPot.gameObject.SetActive(false);
        snow_joystick.gameObject.SetActive(false);
        ice.gameObject.SetActive(false);
        potion.gameObject.SetActive(false);
        colorAsk.gameObject.SetActive(false);
        color01.gameObject.SetActive(false);
        color02.gameObject.SetActive(false);
        color03.gameObject.SetActive(false);
        color04.gameObject.SetActive(false);
        spoid.gameObject.SetActive(false);
        final_comment01.gameObject.SetActive(false);
        final_comment02.gameObject.SetActive(false);
        final_comment03.gameObject.SetActive(false);
        final_comment04.gameObject.SetActive(false);
        final_comment05.gameObject.SetActive(false);

        intro = GameObject.Find("All").GetComponent<Intro>();
        Light = GameObject.Find("S_P").transform.Find("seed").GetComponent<Seedposition>();
        p1= GameObject.Find("Plant1").GetComponent<Plant01>();
        //iceball = GameObject.Find("ICE").GetComponent<Ice>();
        tank= GameObject.Find("03_snowtank").GetComponent<snowtank>();
        p2 = GameObject.Find("Plant2").GetComponent<Plant02>();

    }

    // Update is called once per frame
    void Update()
    {
        if (intro.state == true && IsDestroy1 == false)
            Invoke("PlayIntro", 2f);
      
        if ( Light.standOn == true && IsDestroy2 == false)
            Invoke("PlayStand", 1f);

        if (Light.Music == true && IsDestroy2_1 == false)
            Invoke("PlayMusic", 1.5f);

        if (Light.appear == true && IsDestroy3 == false)
            Invoke("PlayWater", 1.5f);

        if (p1.state == true && IsDestroy4 == false)
            Invoke("PlaySnow", 1.5f);

        //if (iceball.istate == true && IsDestroy5 == false)
        //    Invoke("PlayIce", 1.5f);

        if (tank.pstate == true && IsDestroy5 == false)
            Invoke("PlayIce", 4f);

        if (p2.reach == true && IsDestroy6 == false && IsDestroy7==false && IsDestroy7_1 == false && IsDestroy7_2 == false && IsDestroy7_3 == false && IsDestroy7_4 == false)
        {
            Invoke("PlayPotion", 1.5f);
            Invoke("PlayColorAsk", 6.8f);

        }

    }

    void PlayIntro()
    {
        GameObject.Find("Canvas").transform.Find("01").gameObject.SetActive(true);
        Destroy(seedmachine, 5f);
        IsDestroy1 = true;
    }

    void PlayStand()
    {
        GameObject.Find("Canvas").transform.Find("02").gameObject.SetActive(true);
        Destroy(stand, 5f);
        IsDestroy2 = true;
    }

    void PlayMusic()
    {
        GameObject.Find("Canvas").transform.Find("02-1").gameObject.SetActive(true);
        Destroy(musicLP, 4f);
        IsDestroy2_1 = true;
    }

    void PlayWater()
    {
        GameObject.Find("Canvas").transform.Find("03").gameObject.SetActive(true);
        Destroy(water, 5f);
        IsDestroy3 = true;
    }

    //물보충

    void PlaySnow()
    {
        GameObject.Find("Canvas").transform.Find("04").gameObject.SetActive(true);
        Destroy(snow_joystick, 5f);
        IsDestroy4 = true;
    }

    void PlayIce()
    {
        GameObject.Find("Canvas").transform.Find("05").gameObject.SetActive(true);
        Destroy(ice, 4f);
        IsDestroy5 = true;
    }

    void PlayPotion()
    {
        GameObject.Find("Canvas").transform.Find("06").gameObject.SetActive(true);
        Destroy(potion, 5f);
        IsDestroy6 = true;
    }

    void PlayColorAsk()
    {
        GameObject.Find("Canvas").transform.Find("07").gameObject.SetActive(true);
        GameObject.Find("Canvas").transform.Find("Button").gameObject.SetActive(true);
        GameObject.Find("Canvas").transform.Find("07-2").gameObject.SetActive(true);
        GameObject.Find("Canvas").transform.Find("07-3").gameObject.SetActive(true);
        GameObject.Find("Canvas").transform.Find("07-4").gameObject.SetActive(true);

        //캔버스 선택
        //4중 하나 선택시 
        //캔버스 7,7-1~7-4 사라지고 
        //꽃생기도록
        if (Input.GetMouseButtonDown(0))
        {           
            RaycastHit hit;        
            Ray touchray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Physics.Raycast(touchray, out hit); // ray가 오브젝트에 부딪힐 경우 

            if (hit.collider.gameObject.name == "07-1")
            {
                if (isMove == false)
                {
                    Debug.Log("pushed");
                    isMove = true;
                    answer1 = true;
                }
            }
            else if (hit.collider.gameObject.name == "07-2")
            {
                if (isMove == false)
                {
                    isMove = true;
                    answer2 = true;
                }
            }
            else if (hit.collider.gameObject.name == "07-3")
            {
                if (isMove == false)
                {
                    isMove = true;
                    answer3 = true;
                }
            }
            else if (hit.collider.gameObject.name == "07-4")
            {
                if (isMove == false)
                {
                    isMove = true;
                    answer4 = true;
                }
            }

        }
        if (answer1 == true || answer2 == true || answer3 == true || answer4 == true)  //포션이 클릭됐다면
        {
            //Destroy(colorAsk);
            //Destroy(color01);
            //Destroy(color02);
            //Destroy(color03);
            //Destroy(color04);

            answered = true;
        }
        IsDestroy7 = true;
        IsDestroy7_1 = true;
        IsDestroy7_2 = true;
        IsDestroy7_3 = true;
        IsDestroy7_4 = true;
    }
}
