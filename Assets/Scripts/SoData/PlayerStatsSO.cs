using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class PlayerStatsSO : ScriptableObject
{
    public int startingMoneyLevel;
    public float totalMoney;

    public float GetStartingMoney()
    {
        return startingMoneyLevel * 10f;
    }
    
}
