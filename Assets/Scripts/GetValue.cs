using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GetValue : MonoBehaviour
{
    public TMP_Text ValueX;
    public TMP_Text ValueY;
    public TMP_Text ValueZ;
    public TMP_Text ValueW;

    Vector3 rotation;
    float waitTime = 3.0f;
    float thresholdValue = 1.5f;

    enum Mode{
        None,
        Open,
        Close
    }
    Mode currentMode;
    bool frontFlag = false;
    bool backFlag = false;

    void Start(){
        Input.gyro.enabled = true;  
        currentMode = Mode.None;  
    }
    //Zの変遷で決定する おそよ1.5
    void FixedUpdate(){
        this.rotation = Input.gyro.rotationRate;
        // ValueX.text = this.rotation.x.ToString();
        // ValueY.text = this.rotation.y.ToString();
        // ValueZ.text = this.rotation.z.ToString();
        // ValueW.text = this.gyro.w.ToString();
        if(rotation.z > thresholdValue){
            
        }
    }
}
