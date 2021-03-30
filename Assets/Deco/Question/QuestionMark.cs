using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionMark : MonoBehaviour
{
    public GameObject mark;
    Book books;
    Intro intro;
    bool stateMark;

    void Start()
    {
        mark.gameObject.SetActive(false);
        books = GameObject.Find("book").GetComponent<Book>();
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
                Invoke("Play", 1f);
           
               
        }
        if (intro.state == true)
        {
            //mark.gameObject.SetActive(false);
            Destroy(mark);
            stateMark = false;

        }


    }

    void Play()
    {
        if (stateMark)
        {
            GameObject.Find("Q").transform.Find("question_mark").gameObject.SetActive(true);
        }
    }
}
