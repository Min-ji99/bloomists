using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fade : MonoBehaviour
{
    public UnityEngine.UI.Image fade;
    float fades = 1.0f;
    float time = 0;


    void Start()
    {
        
    }

    void Update()
    {

        Invoke("Fadeslow", 3.5f);
    }

    void Fadeslow()
    {
        time += Time.deltaTime;

        if (fades > 0.0f && time >= 0.1f)
        {
            fades -= 0.1f;
            fade.color = new Color(255, 255, 255, fades);
            time = 0;
        }
        else if (fades <= 0.0f)
        {
            time = 0;
        }
    }


}
