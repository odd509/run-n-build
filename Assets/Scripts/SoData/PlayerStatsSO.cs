using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class PlayerStatsSO : ScriptableObject
{
    public int startingMoneyLevel;
    public float totalMoney;

    [SerializeField] private int resetStartingMoneyLevel;
    [SerializeField] private float resetTotalMoney;

    private void OnEnable()
    {
        startingMoneyLevel = resetStartingMoneyLevel;
        totalMoney = resetTotalMoney;
    }


    public float GetStartingMoney()
    {
        return startingMoneyLevel * 10f;
    }
    
}
