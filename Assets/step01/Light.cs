﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Light : MonoBehaviour
{

    public GameObject light;
    public bool state = false;
    public bool standOn = false;
    
   

    stand_anim sta;

    public AudioSource stlight;

    // Start is called before the first frame update
    void Start()
    {
        light.gameObject.SetActive(false);
        sta = GameObject.Find("01").transform.Find("stand").GetComponent<stand_anim>();
        AudioSource stlight = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

        if (sta.state == true)
        {

            Invoke("Play", 5.0f);
        }

    }


    void Play()
    {
        if(standOn==false)
        {
            
            stlight.Play();
            standOn = true;
        }
        
        GameObject.Find("StandLight").transform.Find("sLight").gameObject.SetActive(true);
        
        state = true;
        

    }

}