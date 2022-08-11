using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Price : MonoBehaviour
{

    public int price;
    public TextMeshProUGUI priceText;
    
    // Start is called before the first frame update
    void Start()
    {
        priceText.text = price.ToString() + "$";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
