using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using System.IO.Ports;
using ArduinoBluetoothAPI;
using System;

public class Sensor : MonoBehaviour
{
    public Seedposition seedPos;
    public watertank tank;
    public Canvas_UI canvas;

    BluetoothHelper bluetoothHelper;

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

    }

    // Update is called once per frame
    void Update()
    {

    }
    //Asynchronous method to receive messages
    void OnMessageReceived()
    {
        received_message = bluetoothHelper.Read();

        //Debug.Log(received_message);

        if (received_message.Contains("Light Detect"))
        {
            if (seedPos.state)
            {
                lightDetect = true;
                Debug.Log("Light 감지" + lightDetect);
            }

        }
        else if (received_message.Contains("potion Object close"))
        {
            if (canvas.IsDestroy8)
            {
                potionDetect = true;
                Debug.Log("Potion 감지" + potionDetect);
            }

        }
        else if (received_message.Contains("Water Object close"))
        {
            if (tank.watering)
            {
                waterDetect = true;
                Debug.Log("Water 감지" + waterDetect);
            }
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
