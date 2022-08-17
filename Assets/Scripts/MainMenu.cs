using System;
using System.Collections;
using System.Collections.Generic;
using System.Timers;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public PlayerStatsSO playerStatsSO;
    public GameObject player;

    [Header("Starting Money")]
    public float startingMoneyUpgradeBaseCost;
    public TextMeshProUGUI startingMoneyUpgradeText;
    private float _upgradeStartingMoneyCost;

    [Header("Bargain")]
    public float bargainUpgradeBaseCost;
    public TextMeshProUGUI bargainUpgradeText;
    private float _upgradeBargainCost;
    
    [Header("Total Money")] public TextMeshProUGUI totalMoneyText;
    
    
    private void Awake()
    {
        _upgradeStartingMoneyCost = Mathf.Round(Mathf.Pow(1.2f, playerStatsSO.startingMoneyLevel - 1) * startingMoneyUpgradeBaseCost);
        startingMoneyUpgradeText.text = "Cost: " + _upgradeStartingMoneyCost + "$<br>Level: " + playerStatsSO.startingMoneyLevel;

        _upgradeBargainCost = Mathf.Round(Mathf.Pow(1.2f, playerStatsSO.betterBargainLevel - 1) * bargainUpgradeBaseCost);
        bargainUpgradeText.text = "Cost: " + _upgradeBargainCost + "$<br>Level: " + playerStatsSO.betterBargainLevel;

        
    }

    private static float t = 0.0f;
    private void Update()
    {
        totalMoneyText.text = Mathf.Round(Mathf.Lerp(0, playerStatsSO.totalMoney, t)) + "$";
        t += 0.4f * Time.deltaTime;
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
        if (playerStatsSO.totalMoney >= _upgradeStartingMoneyCost)
        {
            playerStatsSO.totalMoney -= _upgradeStartingMoneyCost;
            playerStatsSO.startingMoneyLevel++;
            
            _upgradeStartingMoneyCost = Mathf.Round(Mathf.Pow(1.2f, playerStatsSO.startingMoneyLevel - 1) * startingMoneyUpgradeBaseCost);
            startingMoneyUpgradeText.text = "Cost: " + _upgradeStartingMoneyCost + "$<br>Level: " + playerStatsSO.startingMoneyLevel;
            
            totalMoneyText.text = playerStatsSO.totalMoney + "$";
        }
    }
    
    public void UpgradeBargain()
        {
            if (playerStatsSO.totalMoney >= _upgradeBargainCost)
            {
                playerStatsSO.totalMoney -= _upgradeBargainCost;
                playerStatsSO.betterBargainLevel++;
                
                _upgradeBargainCost = Mathf.Round(Mathf.Pow(1.2f, playerStatsSO.betterBargainLevel - 1) * bargainUpgradeBaseCost);
                bargainUpgradeText.text = "Cost: " + _upgradeBargainCost + "$<br>Level: " + playerStatsSO.betterBargainLevel;
                
                totalMoneyText.text = playerStatsSO.totalMoney + "$";
            }
        }

}
