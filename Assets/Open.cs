using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Open : MonoBehaviour
{
    Seedposition seedPos;

    void Start()
    {
        seedPos = GameObject.Find("S_P").transform.Find("seed").GetComponent<Seedposition>();
    }

    // Update is called once per frame
    void Update()
    {
        if (seedPos.state)
        {
           
            GameObject.Find("SeedOpen").transform.Find("seed_open").gameObject.SetActive(true);   //씨앗 나타나게
        }
    }
}
