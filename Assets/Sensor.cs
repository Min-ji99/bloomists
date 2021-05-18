using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using System.IO.Ports;
using ArduinoBluetoothAPI;
using System;

public class Sensor : MonoBehaviour
{
    BluetoothHelper bluetoothHelper;
    //SerialPort sp = new SerialPort("COM4", 9600);
    //string stream;

    public bool lightDetect = false;
    public bool waterDetect = false;
    public bool potionDetect = false;

    string received_message;
    string deviceName;
    // Start is called before the first frame update
    void Start()
    {
        deviceName = "bloomist";
        try
        {
            BluetoothHelper.BLE = false;
            bluetoothHelper = BluetoothHelper.GetInstance(deviceName);
            bluetoothHelper.OnConnected += OnConnected;
            bluetoothHelper.OnConnectionFailed += OnConnectionFailed;
            bluetoothHelper.OnDataReceived += OnMessageReceived; //read the data

            //bluetoothHelper.OnScanEnded += OnScanEnded;

            bluetoothHelper.setTerminatorBasedStream("\n");

            if (!bluetoothHelper.ScanNearbyDevices())
            {
                bluetoothHelper.Connect();
            }
            //if (bluetoothHelper.isDevicePaired())
            //    Toggle_isDevicePaired.isOn = true;
            //else
            //    Toggle_isDevicePaired.isOn = false;
        }
        catch (Exception ex)
        {
            //Toggle_isDevicePaired.isOn = false;
            Debug.Log(ex.Message);
        }
        //sp.Open();
        //sp.ReadTimeout = 1;
    }

    // Update is called once per frame
    void Update()
    {
        /*if (bluetoothHelper.Available)
        {
            Debug.Log("receive");
            received_message = bluetoothHelper.Read();
            Debug.Log(received_message);
        }*/
        //if (sp.IsOpen)
        //{
        //    try
        //    {
        //        stream = sp.ReadLine();
        //        sp.ReadTimeout = 100;
        //        if (stream.Equals("Light Detect"))
        //        {
        //            lightDetect = true;
        //            Debug.Log("Light 감지" + lightDetect);

        //        }
        //        else if (stream.Equals("potion Object close"))
        //        {
        //            potionDetect = true;
        //            Debug.Log("Potion 감지" + potionDetect);
        //        }
        //        else if (stream.Equals("Water Object close"))
        //        {
        //            waterDetect = true;
        //            Debug.Log("Water 감지" + waterDetect);
        //        }
        //    }
        //    catch (System.Exception) { }
        //}
    }
    //Asynchronous method to receive messages
    void OnMessageReceived()
    {
        received_message = bluetoothHelper.Read();

        //Debug.Log(received_message);

        if (received_message.Contains("Light Detect"))
        {
            lightDetect = true;
            Debug.Log("Light 감지" + lightDetect);

        }
        else if (received_message.Contains("potion Object close"))
        {
            potionDetect = true;
            Debug.Log("Potion 감지" + potionDetect);
        }
        else if (received_message.Contains("Water Object close"))
        {
            waterDetect = true;
            Debug.Log("Water 감지" + waterDetect);
        }
    }
    void OnConnected()
    {
        //Toggle_isConnected.isOn = true;
        try
        {
            bluetoothHelper.StartListening();
            Debug.Log("Connected");
        }
        catch (Exception ex)
        {
            Debug.Log(ex.Message);
        }
    }

    void OnConnectionFailed()
    {

        //Toggle_isConnected.isOn = false;
        Debug.Log("Connection Failed");
    }
    void OnDestroy()
    {
        if (bluetoothHelper != null)
            bluetoothHelper.Disconnect();
    }
}
