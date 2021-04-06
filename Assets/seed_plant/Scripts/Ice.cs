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


        if (stank.pstate == true)
        {
            Invoke("Play", 2f);
            Invoke("IceSound", 2f);
        }
        

    }

    void Play()
    {
        GameObject.Find("ICE").transform.Find("03_ice").gameObject.SetActive(true);
        istate = true;
        
    }

    void IceSound()
    {
        icemake.Play();
    }
}
