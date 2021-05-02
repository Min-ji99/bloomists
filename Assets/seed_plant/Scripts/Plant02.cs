using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plant02 : MonoBehaviour
{
    public GameObject Plant;
    public GameObject potion;
    private float Dist;
    public bool state = false;
    public bool reach = false;

    Plant01 p1;
    PotionTank pt;

    color1 col1;
    color2 col2;
    color3 col3;
    color4 col4;


    void Start()
    {
        Plant.gameObject.SetActive(false);  //plant02 안보여
        p1 = GameObject.Find("Plant1").GetComponent<Plant01>();
        pt = GameObject.Find("04_tank").GetComponent<PotionTank>();

        col1 = GameObject.Find("Canvas_UI").transform.Find("10-1").GetComponent<color1>();
        col2 = GameObject.Find("Canvas_UI").transform.Find("10-2").GetComponent<color2>();
        col3 = GameObject.Find("Canvas_UI").transform.Find("10-3").GetComponent<color3>();
        col4 = GameObject.Find("Canvas_UI").transform.Find("10-4").GetComponent<color4>();
    }

    void Update()
    {
        if (state == false) // false일동안 step03
        {
            PlantAppear();
        }
        Dist = Vector3.Distance(Plant.transform.position, potion.transform.position);
       
    }

  

    void PlantAppear()
    {


        if (p1.state == true)   //plant01이 사라졌다면
        {
            
            Play();

    
        }
       
        if (col1.answer1 == true || col2.answer2 == true || col3.answer3 == true || col4.answer4 == true) {    //물약기계 움직였다면

            Invoke("Disappear", 4.0f);  //4초 뒤에 사라졋!!~!~

        }
    }

    void LateUpdate()
    {
       // print("Dist : " + Dist);
    }

    void Play()
    {
        GameObject.Find("Plant2").transform.Find("plant02").gameObject.SetActive(true); //plant02 생김
        

        if (Dist < 0.5725f)  //plant02 자라난 뒤 step04로 다가가면
        {

            reach = true; //roller 정지상태 켜줌
        }
    }

    void Disappear()
    {
        state = true;      //사라졌다면
        Plant.gameObject.SetActive(false);  //plant02사라지구
       // p1.appear = false;  
    }

}
