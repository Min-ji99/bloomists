using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tt : MonoBehaviour
{

    //title 이미지
    public GameObject t1;
    public GameObject t2;
    public GameObject t3;
    public GameObject all;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //title
        Invoke("tt1", 1.5f);
        Invoke("tt2", 2.5f);
        Invoke("tt3", 3.5f);
        Invoke("TitleSize", 7f);
    }

    void tt1()
    {
        t1.gameObject.SetActive(true);
        Destroy(t1, 5.5f);
    }

    void tt2()
    {
        t2.gameObject.SetActive(true);
        Destroy(t2, 4.5f);
    }

    void tt3()
    {
        t3.gameObject.SetActive(true);
        Destroy(t3, 3.5f);
    }

    void TitleSize()
    {
        all.SetActive(true);
        Destroy(all, 8f);
    }
}
