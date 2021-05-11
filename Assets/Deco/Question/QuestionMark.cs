using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionMark : MonoBehaviour
{
    public GameObject mark;
    Book books;
    Intro intro;
    bool stateMark;
    public bool isDestroyed = false;

    public ParticleSystem seed_intro;
    private bool ParticleDestroyed = false;

    void Start()
    {
        mark.gameObject.SetActive(false);
        books = GameObject.Find("book_rotate").GetComponent<Book>();
        intro = GameObject.Find("All").GetComponent<Intro>();
        stateMark = true;
    }

    void Update()
    {
        touchClick();
    }

    void touchClick()
    {
        

        if (books.state==true)
        {
            Invoke("Play", 1f);  //28f
            Invoke("particle", 1.5f); //28.5f
            
               
        }
        if (intro.state == true)
        {
            //mark.gameObject.SetActive(false);
            Destroy(mark);
            isDestroyed = true;
            stateMark = false;

        }


    }

    void Play()
    {
        if (stateMark)
        {
            GameObject.Find("Q").transform.Find("seed").gameObject.SetActive(true);
        }
    }

    void particle()
    {
        if(ParticleDestroyed == false) 
        {
            seed_intro.Play();
            Destroy(seed_intro, 2f);
            ParticleDestroyed = true;
        }
    }
}
