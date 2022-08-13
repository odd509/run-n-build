using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraOscillator : MonoBehaviour
{


    public float speed;
    private float _flipper = 1;
    public float flipTimer;
    private float flipCountdown;

    private void Awake()
    {
        flipCountdown = flipTimer;
    }

    private void Update()
    {
       
        flipCountdown -= Time.deltaTime;
        transform.Rotate(0, speed * Time.deltaTime * _flipper, 0);
        if (flipCountdown <= 0.0f)
        {
            _flipper = -_flipper;
            flipCountdown = flipTimer;
        }
        
    }
}
