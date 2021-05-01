using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class last_end : MonoBehaviour
{
    public GameObject cir;
    public GameObject hall;

    //title fade
    public UnityEngine.UI.Image fade;
    float fades = 1.0f;
    float time = 0;


    void Update()
    {
        Invoke("circle", 3f);
        Invoke("appear", 3.5f);
        Invoke("Fadeslow", 4.5f);

    }

    void appear()
    {
        hall.gameObject.SetActive(true);
    }

    void circle()
    {
        cir.gameObject.SetActive(true);
    }

    void Fadeslow()
    {
        fade.gameObject.SetActive(true);

        time += Time.deltaTime;

        if (fades > 0.0f && time >= 0.1f)
        {
            fades -= 0.1f;
            fade.color = new Color(0, 0, 0, fades);
            time = 0;
        }
        else if (fades <= 0.0f)
        {
            time = 0;
        }
    }

}
