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
    private bool IsDestroy3 = false;
    private bool IsDestroy4 = false;
    private bool IsDestroy5 = false;
    private bool IsDestroy6 = false;
    private bool IsDestroy7 = false;
    private bool IsDestroy8 = false;
    private bool IsDestroy9 = false;
    private bool IsDestroy10 = false;
    private bool IsDestroy11 = false;
    private bool IsDestroy12 = false;
    private bool IsDestroy13 = false;
    private bool IsDestroy14 = false;
    public bool IsDestroy15 = false;


    Intro intro;
    Seedposition Light;
    Plant01 p1;
    //Ice iceball;
    snowtank tank;
    Plant02 p2;
    Flower01 f1;
    Flower2 f2;
    Fruit01 f01;
    Fruit02 f02;
    final_machine Fmachine;

    color1 col1;
    color2 col2;
    color3 col3;
    color4 col4;


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

        f1 = GameObject.Find("Flower1").GetComponent<Flower01>();
        f2 = GameObject.Find("Flower2").GetComponent<Flower2>();
        f01 = GameObject.Find("Fruit1").GetComponent<Fruit01>();
        f02 = GameObject.Find("Fruit2").GetComponent<Fruit02>();

        Fmachine= GameObject.Find("final_final").GetComponent<final_machine>();

        col1 = GameObject.Find("Canvas_UI").transform.Find("10-1").GetComponent<color1>();
        col2 = GameObject.Find("Canvas_UI").transform.Find("10-2").GetComponent<color2>();
        col3 = GameObject.Find("Canvas_UI").transform.Find("10-3").GetComponent<color3>();
        col4 = GameObject.Find("Canvas_UI").transform.Find("10-4").GetComponent<color4>();

    }

    // 각 위치에서 캔버스 뜨기 위한 조건
    void Update()
    {
        if (intro.state == true && IsDestroy1 == false)
            Invoke("PlayIntro", 2f);
      
        if ( Light.standOn == true && IsDestroy2 == false)
            Invoke("PlayStand", 1f);

        if (Light.Music == true && IsDestroy3 == false)
            Invoke("PlayMusic", 1.5f);

        if (Light.appear == true && IsDestroy4 == false)
            Invoke("PlayWater", 1.5f);

        if (p1.extraWater == true && IsDestroy5 == false)
            Invoke("PlayExtraWater", 0.5f);

        if (p1.state == true && IsDestroy6 == false)
            Invoke("PlaySnow", 1.5f);

        //if (iceball.istate == true && IsDestroy5 == false)
        //    Invoke("PlayIce", 1.5f);

        if (tank.pstate == true && IsDestroy7 == false)
            Invoke("PlayIce", 4f);

        if (p2.reach == true && IsDestroy8 == false)
        {
            Invoke("PlayPotion", 1.5f);
            Invoke("PlayColorAsk", 6.8f);

        }

        if(IsDestroy10 == false && (col1.answer1 == true || col2.answer2 == true || col3.answer3 == true || col4.answer4 == true))
        {
            Invoke("PlaySpoid", 1f);
        }

        if( IsDestroy11 == false && (f1.flower1reach == true || f2.flower2reach == true || f01.fruit1reach == true || f02.fruit2reach == true))
        {
            Invoke("PlayFinalComment01",1.5f);
        }

        if (IsDestroy11== true && IsDestroy12==false)
        {
            Invoke("PlayFinalComment02", 5.5f);
        }

        if (IsDestroy12 == true && IsDestroy13 == false)
        {
            Invoke("PlayFinalComment03", 5.5f);
        }

        if(Fmachine.isclosed==true && IsDestroy14 == false)
        {
            Invoke("PlayFinalComment04", 4.5f);
        }

        if (IsDestroy14 == true && IsDestroy15 == false)
        {
            Invoke("PlayFinalComment05", 2.5f);
        }
    }

    //캔버스 나타나고 몇초 뒤 사라지게
    void PlayIntro()
    {
        GameObject.Find("Canvas_UI").transform.Find("01").gameObject.SetActive(true);
        Destroy(seedmachine, 5f);
        IsDestroy1 = true;
    }

    void PlayStand()
    {
        GameObject.Find("Canvas_UI").transform.Find("02").gameObject.SetActive(true);
        Destroy(stand, 5f);
        IsDestroy2 = true;
    }

    void PlayMusic()
    {
        GameObject.Find("Canvas_UI").transform.Find("03").gameObject.SetActive(true);
        Destroy(musicLP, 4f);
        IsDestroy3 = true;
    }

    void PlayWater()
    {
        GameObject.Find("Canvas_UI").transform.Find("04").gameObject.SetActive(true);
        Destroy(water, 5f);
        IsDestroy4 = true;
    }

    void PlayExtraWater() //물보충
    {
        GameObject.Find("Canvas_UI").transform.Find("05").gameObject.SetActive(true);
        Destroy(waterPot, 3f);
        IsDestroy5 = true;
    }


    void PlaySnow()
    {
        GameObject.Find("Canvas_UI").transform.Find("06").gameObject.SetActive(true);
        Destroy(snow_joystick, 5f);
        IsDestroy6 = true;
    }

    void PlayIce()
    {
        GameObject.Find("Canvas_UI").transform.Find("07").gameObject.SetActive(true);
        Destroy(ice, 4f);
        IsDestroy7 = true;
    }

    void PlayPotion()
    {
        GameObject.Find("Canvas_UI").transform.Find("08").gameObject.SetActive(true);
        Destroy(potion, 5f);
        IsDestroy8 = true;
    }

    void PlayColorAsk()
    {
        GameObject.Find("Canvas_UI").transform.Find("09").gameObject.SetActive(true);
        GameObject.Find("Canvas_UI").transform.Find("10-1").gameObject.SetActive(true);
        GameObject.Find("Canvas_UI").transform.Find("10-2").gameObject.SetActive(true);
        GameObject.Find("Canvas_UI").transform.Find("10-3").gameObject.SetActive(true);
        GameObject.Find("Canvas_UI").transform.Find("10-4").gameObject.SetActive(true);

    }

    void PlaySpoid()//물약 뿌리기
    {
        GameObject.Find("Canvas_UI").transform.Find("10").gameObject.SetActive(true);
        Destroy(spoid, 3f);
        IsDestroy10 = true;
    }

    void PlayFinalComment01()
    {
        GameObject.Find("Canvas_UI").transform.Find("11").gameObject.SetActive(true);
        Destroy(final_comment01, 5f);
        IsDestroy11 = true;
    }

    void PlayFinalComment02()
    {
        GameObject.Find("Canvas_UI").transform.Find("12").gameObject.SetActive(true);
        Destroy(final_comment02, 5f);
        IsDestroy12 = true;
    }

    void PlayFinalComment03()
    {
        GameObject.Find("Canvas_UI").transform.Find("13").gameObject.SetActive(true);
        Destroy(final_comment03, 3f);
        IsDestroy13 = true;
    }

    void PlayFinalComment04()
    {
        GameObject.Find("Canvas_UI").transform.Find("14").gameObject.SetActive(true);
        Destroy(final_comment04, 2f);
        IsDestroy14 = true;
    }

    void PlayFinalComment05()
    {
        GameObject.Find("Canvas_UI").transform.Find("15").gameObject.SetActive(true);
        Destroy(final_comment05, 5f);
        IsDestroy15 = true;
    }
}
