using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public PlayerStatsSO playerStatsSO;

    [Header("Starting Money")]
    public float startingMoneyUpgradeBaseCost;
    public TextMeshProUGUI startingMoneyUpgradeText;
    private float _upgradeCost;

    [Header("Total Money")] public TextMeshProUGUI totalMoneyText;
    
    
    private void Awake()
    {
        _upgradeCost = Mathf.Round(Mathf.Pow(1.2f, playerStatsSO.startingMoneyLevel - 1) * startingMoneyUpgradeBaseCost);
        startingMoneyUpgradeText.text = "Cost: " + _upgradeCost + "$<br>Level: " + playerStatsSO.startingMoneyLevel;

        totalMoneyText.text = playerStatsSO.totalMoney + "$";
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void UpgradeStartingMoney()
    {
        if (playerStatsSO.totalMoney >= _upgradeCost)
        {
            playerStatsSO.totalMoney -= _upgradeCost;
            playerStatsSO.startingMoneyLevel++;
            
            _upgradeCost = Mathf.Round(Mathf.Pow(1.2f, playerStatsSO.startingMoneyLevel - 1) * startingMoneyUpgradeBaseCost);
            startingMoneyUpgradeText.text = "Cost: " + _upgradeCost + "$<br>Level: " + playerStatsSO.startingMoneyLevel;
            
            totalMoneyText.text = playerStatsSO.totalMoney + "$";
        }
    }

}
