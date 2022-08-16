using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Collectable : MonoBehaviour
{

    public float price;
    public TextMeshProUGUI priceText;
    
    [Header("Oscillator Stats")]
    public float speed;
    private float _flipper = 1;
    public float flipTimer;
    private float flipCountdown;

    public GameObject pairItem;

    public CollectableType type;
    public enum CollectableType
    {
        Door,
        Wall,
        Roof,
        Window,
        Cash
    }

    private void Awake()
    {
        flipCountdown = flipTimer;
        
        //initial rotation
        
        

    }

    void Start()
    {
        
        priceText.text = price.ToString() + "$";
    }
    
    // Update is called once per frame
    void Update()
    {
       Oscillator(); 
    }
    private void Oscillator()
    {
        flipCountdown -= Time.deltaTime;
        transform.Rotate(0, speed * Time.deltaTime * _flipper, 0);
        if (!(flipCountdown <= 0.0f)) return;
        
        _flipper = -_flipper;
        flipCountdown = flipTimer;
    }

   
}
