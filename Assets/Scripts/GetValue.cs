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

    Quaternion gyro;
    
    void Start(){
        Input.gyro.enabled = true;    
    }

    void FixedUpdate(){
        this.gyro = Input.gyro.attitude;
        ValueX.text = this.gyro.x.ToString();
        ValueY.text = this.gyro.y.ToString();
        ValueZ.text = this.gyro.z.ToString();
        ValueW.text = this.gyro.w.ToString();
    }
}
