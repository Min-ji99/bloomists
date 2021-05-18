using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class guideline : MonoBehaviour
{
    public TrackedImage AR;
    public GameObject guide;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (AR.ar)
        {
            Destroy(guide);
        }
    }
}
