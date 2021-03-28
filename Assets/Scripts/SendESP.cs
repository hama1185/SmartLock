using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using SerialPortUtility;
using TMPro;

public class SendESP : MonoBehaviour
{
    SerialPortUtilityPro serialPort;
    public TMP_Text device;
    void Awake(){
        serialPort = GetComponent<SerialPortUtilityPro>();
    }

    void Start() {
        var list = SerialPortUtilityPro.GetConnectedDeviceList(SerialPortUtilityPro.OpenSystem.BluetoothSSP);
        device.text = list.ToString();
    }

    // Update is called once per frame
    void Update() {
        
    }
}
