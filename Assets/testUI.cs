using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testUI : MonoBehaviour
{
    public GameObject colorAsk;
    public GameObject color01;
    public GameObject color02;
    public GameObject color03;
    public GameObject color04;

   // public GameObject Building;

    public void BuildingSetActive()
    {
        //Building.SetActive(!Building.active);
        Invoke("disappear",1f);


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
