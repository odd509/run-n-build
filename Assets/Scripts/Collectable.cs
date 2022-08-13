using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Collectable : MonoBehaviour
{

    public float price;
    public TextMeshProUGUI priceText;

    public CollectableType type;
    public enum CollectableType
    {
        Door,
        Wall,
        Sealing,
        Window
    }
    
    void Start()
    {
        
        priceText.text = price.ToString() + "$";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
