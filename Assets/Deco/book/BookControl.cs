using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookControl : MonoBehaviour
{
    public GameObject book;

    QuestionMark QM;

    // Start is called before the first frame update
    void Start()
    {
        QM = GameObject.Find("Q").GetComponent<QuestionMark>();
    }

    // Update is called once per frame
    void Update()
    {
        if (QM.isDestroyed == true)
        {
            Destroy(book);
        }
    }
}
