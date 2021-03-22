using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plant01 : MonoBehaviour
{
    public GameObject Plant;
    public GameObject icebox;
    private float Dist;
    public bool state = false;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Dist = Vector3.Distance(Plant.transform.position, icebox.transform.position);
        Play();
    }

    void LateUpdate()
    {
        //print("Dist : " + Dist);
    }



    void Play()
    {
        if (Dist < 0.4f)
        {
            Plant.gameObject.SetActive(false);
            state = true;
        }
    }


}
