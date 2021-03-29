using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GetValue : MonoBehaviour
{
    public GameObject connectManager;
    public GameObject openImage;
    public GameObject closeImage;

    public TMP_Text now;

    Vector3 rotation;
    udptest udptest;
    float waitTime = 3.0f;
    float thresholdValue = 4.0f;

    enum Mode{
        None,
        Open,
        Close
    }
    Mode currentMode;

    bool openFirstFlag = false;
    bool openSecondFlag = false;
    
    bool closeFirstFlag = false;
    bool closeSecondFlag = false;

    void Start(){
        Input.gyro.enabled = true;  
        currentMode = Mode.None;
        udptest = connectManager.GetComponent<udptest>();  
    }
    //Zの変遷で決定する おそよ1.5
    void FixedUpdate(){
        this.rotation = Input.gyro.rotationRate;
        
        
        // 閾値の判定

        if(rotation.z > thresholdValue){
            if(closeFirstFlag){
                closeSecondFlag = true;
            }
            else{
                openFirstFlag = true;
            }
        }
        if(rotation.z < -thresholdValue){
            if(openFirstFlag){
                openSecondFlag = true;
            }
            else{
                closeFirstFlag = true;
            }
        }

        // flagの判定

        if(openFirstFlag && openSecondFlag){
            currentMode = Mode.Open;
            openImage.SetActive(true);
            udptest.sendopendataUDP();
            Invoke("reset", waitTime);
        }
        else if(closeFirstFlag && closeSecondFlag){
            currentMode = Mode.Close;
            closeImage.SetActive(true);
            udptest.sendclosedataUDP();
            Invoke("reset", waitTime);
        }
        else{
            currentMode = Mode.None;
        }

        now.text = currentMode.ToString();
    }

    void reset(){
        currentMode = Mode.None;
        openImage.SetActive(false);
        closeImage.SetActive(false);
        openFirstFlag = false;
        openSecondFlag = false;
        closeFirstFlag = false;
        closeSecondFlag = false;
    }
}
