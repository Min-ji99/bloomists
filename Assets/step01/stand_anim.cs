using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stand_anim : MonoBehaviour
{
    Seedposition Sp;
 

    private Animator animator;
    public bool state = false;


    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        Sp = GameObject.Find("S_P").transform.Find("seed").GetComponent<Seedposition>();
 
    }

    // Update is called once per frame
    void Update()
    {
        if (Sp.state==true)
        {
            //animator.SetBool("Click", true);
            Invoke("Play",0.5f);
        }
    }

    void Play()
    {
        animator.SetBool("Click", true);
        state = true;
        
    }
}
