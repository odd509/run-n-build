using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButton : MonoBehaviour
{
    public PlayerStatsSO PlayerStatsSo;
    public GameObject player;
    
    public void LoadMenu()
    {
        SceneManager.LoadScene(0);
        PlayerStatsSo.totalMoney += 1000;
    }
    
    public void SellHouse()
    {
        player.GetComponent<PlayerCounter>().ToSoldForScene();
    }
}
