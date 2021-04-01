using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plant01 : MonoBehaviour
{
    public GameObject Plant;
    public GameObject icebox;
    private float Dist;
    public bool state = false;
    public bool appear = false;

    Seedposition seedPos;

    void Start()
    {
        Plant.gameObject.SetActive(false);
        seedPos = GameObject.Find("S_P").transform.Find("seed").GetComponent<Seedposition>();
    }

    // Update is called once per frame
    void Update()
    {
        Dist = Vector3.Distance(Plant.transform.position, icebox.transform.position);

        if (state==false)
        {
            PlantAppear();
        }
        
    }

    void LateUpdate()
    {
        //print("Dist : " + Dist);
    }



    void PlantAppear()
    {

        if (seedPos.state2 == true)
        {
            Play();
        }

        if (Dist < 0.4f)
        {
            Plant.gameObject.SetActive(false);
            state = true;
        }

       
    }
    void Play()
    {
        GameObject.Find("Plant1").transform.Find("plant01").gameObject.SetActive(true);
        appear = true;
    }

}
