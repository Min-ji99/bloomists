using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Canvas_UI : MonoBehaviour
{
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
    private bool IsDestroy5 = false;

    Intro intro;
    Ice iceball;

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
        iceball = GameObject.Find("ICE").GetComponent<Ice>();
    }

    // Update is called once per frame
    void Update()
    {
        touchClick();
    }

    void touchClick()
    {
        if (intro.state == true && IsDestroy1 == false)
        {
            Invoke("PlayIntro", 3f);
            
        }

        if (iceball.istate == true && IsDestroy5 == false)
        {
            Invoke("PlayIce", 3f);
        }

    }

    void PlayIntro()
    {
        GameObject.Find("Canvas").transform.Find("01").gameObject.SetActive(true);
        Destroy(seedmachine, 5f);
        IsDestroy1 = true;
    }

    void PlayIce()
    {
        GameObject.Find("Canvas").transform.Find("05").gameObject.SetActive(true);
        Destroy(ice, 5f);
        IsDestroy5 = true;
    }
}
