using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;

public class Sensor : MonoBehaviour
{
    SerialPort sp = new SerialPort("COM4", 9600);
    string stream;

    public bool lightDetect = false;
    public bool waterDetect = false;
    public bool potionDetect = false;

    // Start is called before the first frame update
    void Start()
    {
        sp.Open();
        sp.ReadTimeout = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (sp.IsOpen)
        {
            try
            {
                stream = sp.ReadLine();
                sp.ReadTimeout = 100;
                if (stream.Equals("Light Detect"))
                {
                    lightDetect = true;
                    Debug.Log("Light 감지" + lightDetect);

                }
                else if (stream.Equals("potion Object close"))
                {
                    potionDetect = true;
                    Debug.Log("Potion 감지" + potionDetect);
                }
                else if (stream.Equals("Water Object close"))
                {
                    waterDetect = true;
                    Debug.Log("Water 감지" + waterDetect);
                }
            }
            catch (System.Exception) { }
        }
    }
}
