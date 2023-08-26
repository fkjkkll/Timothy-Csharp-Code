using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.Video;



public class test : MonoBehaviour
{
    public Text isSupport;
    public Text showAngleL;
    public Text showAngleR;
    public Button btn;

    private float angle = 10f;
    private float duration = 1f;

    Vector3 _from;
    Vector3 _to;


    float _cc = 0;
    private void Start() {
        _to = transform.eulerAngles;

        btn.onClick.AddListener(Refresh);

        if (SystemInfo.supportsGyroscope) {
            isSupport.text = "֧��";
        }
        else {
            isSupport.text = "��֧��";
        }
    }
    
    void Refresh() {
        if (SystemInfo.supportsGyroscope) {
            Vector3 acc = Vector3.zero;
            float x = Input.acceleration.x;
            float y = Input.acceleration.y;

            acc.x = y > 0 ? -angle : angle;
            acc.y = x > 0 ? angle : -angle;

            _from = _to + acc;
        }
        else {
            _from = _to + new Vector3(angle, angle, 0);
        }
        transform.eulerAngles = _from;
        _cc = 0;
    }
    
    private void FixedUpdate() {
        
        if (SystemInfo.supportsGyroscope) {
            float x = Input.acceleration.x;
            float y = Input.acceleration.y;
            showAngleL.text = "(" + x.ToString("F2") + " , " + y.ToString("F2") + ")";
        }

        if (transform.rotation.x == 0)
            return;

        _cc += Time.deltaTime;
        transform.eulerAngles = Vector3.Lerp(_from, _to, _cc / duration);

        showAngleR.text = transform.eulerAngles.ToString();
    }

}
