using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ice : MonoBehaviour
{
    public GameObject ice;
    public bool istate = false;

    snowtank stank;

    void Start()
    {
        ice.gameObject.SetActive(false);

        stank = GameObject.Find("03_snowtank").GetComponent<snowtank>();

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


        }
        

    }

    void Play()
    {
        GameObject.Find("ICE").transform.Find("03_ice").gameObject.SetActive(true);
        istate = true;
    }
}
