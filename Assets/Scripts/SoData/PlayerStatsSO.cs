using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class PlayerStatsSO : ScriptableObject
{
    [Header("Stats")]
    public int startingMoneyLevel;
    public int betterBargainLevel;
    public float totalMoney;

    [Header("Stat Resets")] public bool allowReset;
    [SerializeField] private int resetStartingMoneyLevel;
    [SerializeField] private int resetBetterBargainLevel;
    [SerializeField] private float resetTotalMoney;

    public Dictionary<Collectable.CollectableType, GameObject> playerInventory = new Dictionary<Collectable.CollectableType, GameObject>();

    private void OnEnable()
    {
        if (allowReset)
        {
            startingMoneyLevel = resetStartingMoneyLevel;
            betterBargainLevel = resetBetterBargainLevel;
            totalMoney = resetTotalMoney;
        }
        
    }


    public float GetStartingMoney()
    {
        return startingMoneyLevel * 10f;
    }
    
}
