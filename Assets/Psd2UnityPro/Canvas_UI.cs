using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Canvas_UI : MonoBehaviour
{
    public GameObject seedmachine;
    public GameObject stand;
    public GameObject water;
    public GameObject snow_joystick;
    public GameObject ice;
    public GameObject potion;
    public GameObject color;
    public GameObject final_lever;
    public GameObject final_comment1;
    public GameObject final_comment2;

    private bool IsDestroy1 = false;
    private bool IsDestroy5 = false;

    Intro intro;
    Ice iceball;

    // Start is called before the first frame update
    void Start()
    {
        seedmachine.gameObject.SetActive(false);
        stand.gameObject.SetActive(false);
        water.gameObject.SetActive(false);
        snow_joystick.gameObject.SetActive(false);
        ice.gameObject.SetActive(false);
        potion.gameObject.SetActive(false);
        color.gameObject.SetActive(false);
        final_lever.gameObject.SetActive(false);
        final_comment1.gameObject.SetActive(false);
        final_comment2.gameObject.SetActive(false);

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
