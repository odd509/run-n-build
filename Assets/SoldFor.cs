using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SoldFor : MonoBehaviour
{

    public float waitSec;
    private float _counter;

    public TextMeshProUGUI soldForTMP;
    private float _soldPrice;
    public PlayerStatsSO playerStatsSo;

    // Start is called before the first frame update
    void Start()
    {
        int itemCount = 0;
        float totalItemPrice = 0;
        foreach (var pair in playerStatsSo.playerInventory)
        {
            itemCount++;
            totalItemPrice += pair.Value.GetComponent<Collectable>().price;
        }

        _soldPrice = Mathf.Pow(1.1f * playerStatsSo.betterBargainLevel, itemCount) * totalItemPrice;

    }

    // Update is called once per frame
    void Update()
    {
        _counter += Time.deltaTime;
        
        
        if (_counter > waitSec)
        {
            GetComponent<Animator>().enabled = true;
            soldForTMP.text = Mathf.Round(Mathf.Lerp(0, _soldPrice, (_counter - waitSec) / 2f)) + "$";
        }
        
        

    }
    
}
