using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Open : MonoBehaviour
{
    Seedposition seedPos;

    public bool isDestroyed = false;

    void Start()
    {
        seedPos = GameObject.Find("S_P").transform.Find("seed").GetComponent<Seedposition>();
    }

    // Update is called once per frame
    void Update()
    {
        if (seedPos.state && isDestroyed==false)
        {
           
            GameObject.Find("SeedOpen").transform.Find("seed_open").gameObject.SetActive(true);   //씨앗 나타나게
        }
    }
}
