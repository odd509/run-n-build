using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class PlayerStatsSO : ScriptableObject
{
    public int startingMoneyLevel;
    public int betterBargainLevel;
    public float totalMoney;

    [SerializeField] private int resetStartingMoneyLevel;
    [SerializeField] private int resetBetterBargainLevel;
    [SerializeField] private float resetTotalMoney;

    private void OnEnable()
    {
        startingMoneyLevel = resetStartingMoneyLevel;
        betterBargainLevel = resetBetterBargainLevel;
        totalMoney = resetTotalMoney;
    }


    public float GetStartingMoney()
    {
        return startingMoneyLevel * 10f;
    }
    
}
