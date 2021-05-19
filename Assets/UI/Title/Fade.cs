using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fade : MonoBehaviour
{
    public UnityEngine.UI.Image fade;
    public Canvas canvas;
    public tt title;

    float fades = 1.0f;
    float time = 0;

    

    void Start()
    {
        canvas.gameObject.SetActive(false);
    }

    void Update()
    {
        if (title.touch)
        {
            Invoke("Fadeslow", 7.5f);
            Invoke("guide", 8.5f);
        }
        // Fadeslow();

    }

    void Fadeslow()
    {
        time += Time.deltaTime;

        if (fades > 0.0f && time >= 0.1f)
        {
            fades -= 0.1f;
            fade.color = new Color(255, 255, 255, fades);
            time = 0;

            Destroy(fade,5.0f);
        }
        else if (fades <= 0.0f)
        {
            time = 0;
        }
    }
    void guide()
    {
        canvas.gameObject.SetActive(true);
    }


}
