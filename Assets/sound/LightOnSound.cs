using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightOnSound : MonoBehaviour
{
    public AudioSource stlight;
    Light light;
    bool state = false;

    // Start is called before the first frame update
    void Start()
    {

        AudioSource stlight = GetComponent<AudioSource>();
        light = GameObject.Find("StandLight").GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        if (light.standOn == true&&state==false)
        {
            stlight.Play();
            state = true;
        }
    }

    
}
