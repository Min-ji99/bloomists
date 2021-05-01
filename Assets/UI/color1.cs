using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class color1 : MonoBehaviour
{
    public GameObject colorAsk;
    public GameObject color01;
    public GameObject color02;
    public GameObject color03;
    public GameObject color04;

    public bool answer1 = false;

    public void BuildingSetActive()
    {
        answer1 = true;
        //Debug.Log(answer1);
        Invoke("disappear", 0.5f);


    }

    void disappear()
    {
        Destroy(colorAsk);
        Destroy(color01);
        Destroy(color02);
        Destroy(color03);
        Destroy(color04);
    }

}
