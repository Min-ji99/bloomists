using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Light : MonoBehaviour
{

    public GameObject light;
    public bool state = false;

    stand_anim sta;

    // Start is called before the first frame update
    void Start()
    {
        light.gameObject.SetActive(false);
        sta = GameObject.Find("01").transform.Find("stand").GetComponent<stand_anim>();
    }

    // Update is called once per frame
    void Update()
    {
        if (sta.state==true)
        {
            Invoke("Play",8.0f);
        }
    }

    void Play()
    {
        GameObject.Find("StandLight").transform.Find("sLight").gameObject.SetActive(true);
        state = true;
    }
}
