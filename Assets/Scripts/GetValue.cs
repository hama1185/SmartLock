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
    Vector3 rotation;
    
    void Start(){
        Input.gyro.enabled = true;    
    }

    void FixedUpdate(){
        this.gyro = Input.gyro.attitude;
        this.rotation = Input.gyro.rotationRate;
        ValueX.text = this.rotation.x.ToString();
        ValueY.text = this.rotation.y.ToString();
        ValueZ.text = this.rotation.z.ToString();
        //ValueW.text = this.gyro.w.ToString();
    }
}
