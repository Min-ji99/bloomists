using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionMark : MonoBehaviour
{
    public GameObject mark;
    Book books;
    Intro intro;

    void Start()
    {
        mark.gameObject.SetActive(false);
        books = GameObject.Find("book").GetComponent<Book>();
        intro = GameObject.Find("All").GetComponent<Intro>();

    }

    void Update()
    {
        touchClick();
    }

    void touchClick()
    {
        

        if (books.state==true)
        {
                Invoke("Play", 17f);
           
               
        }
        if (intro.state == true)
        {
            mark.gameObject.SetActive(false);


        }


    }

    void Play()
    {
         GameObject.Find("Q").transform.Find("question_mark").gameObject.SetActive(true);
    }
}
