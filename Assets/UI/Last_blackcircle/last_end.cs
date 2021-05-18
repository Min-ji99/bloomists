using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class last_end : MonoBehaviour
{
    public GameObject background;
    public GameObject cir;
    public GameObject hole;
    public bool getfade = false;

    //title fade
    public UnityEngine.UI.Image fade;
    //float fades = 0.0f;
    float time = 0;

    Canvas_UI fianlCo;

    void Start()
    {
        fianlCo = GameObject.Find("Canvas_UI").GetComponent<Canvas_UI>();
    }

    void Update()
    {
        if (fianlCo.IsDestroy15 == true) {
            getAppear();
        }
    }

    void getAppear()
    {
        if (getfade == false)
        {
            Invoke("BackGround", 3.5f);
            Invoke("circle", 4.5f);
            Invoke("appear", 5f);
            Invoke("Fadeslow", 5f);        }
    }

    void BackGround()
    {
        background.gameObject.SetActive(true);
    }

    void circle()
    {
        cir.gameObject.SetActive(true);
    }

    void appear()
    {
        hole.gameObject.SetActive(true);
    }

    //void Fadeslow()
    //{
    //    fade.gameObject.SetActive(true);

    //    time += Time.deltaTime;

    //    if (fades <= 0.0f)
    //    {
    //        fade.color = new Color(1, 1, 1, fades);
    //        fades += 0.1f;
    //        //time = 0;
    //    }
    //    else if (fades > 0.0f && time >= 0.1f) 
    //    {
    //        time = 0;
    //    }

    //}

    void Fadeslow()
    {
        getfade = true;
        Invoke("titleAppear", 1f);
        //fade.gameObject.SetActive(true);
        //StartCoroutine(FadeCoroutine());
    }
    void titleAppear()
    {
        fade.gameObject.SetActive(true);
    }
    /*
    IEnumerator FadeCoroutine()
    {
        float fadeCount = 0;    //처음 알파값
        while(fadeCount < 1.0f) //알파 최대값, 1.0까지 반복
        {
            fadeCount += 0.1f;
            Debug.Log("last  : " + fadeCount);
            yield return new WaitForSeconds(0.001f);
            fade.color = new Color(1, 1, 1, fadeCount);
        }
    }*/
}
