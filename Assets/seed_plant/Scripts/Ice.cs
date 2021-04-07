using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ice : MonoBehaviour
{
    public GameObject ice;
    public bool istate = false;

    snowtank stank;

    public AudioSource icemake;

    void Start()
    {
        ice.gameObject.SetActive(false);

        stank = GameObject.Find("03_snowtank").GetComponent<snowtank>();
        AudioSource icemake = GetComponent<AudioSource>();

    }

    void Update()
    {
        touchClick();
    }

    void touchClick()
    {


        if (stank.pstate == true)   //눈 실행됐으면
        {
            //Invoke("IceSound", 2f);
            Invoke("Play", 2f); //2초뒤에 얼음 생겨
            
        }
        

    }

    void Play()
    {
        Debug.Log("PlaySound");
        icemake.Play();
        GameObject.Find("ICE").transform.Find("03_ice").gameObject.SetActive(true);
        istate = true;  //얼음 생긴 상태-> <RemoveIce>
        
    }

    //void IceSound()
    //{
    //    
    //    icemake.Play();
    //}
}
