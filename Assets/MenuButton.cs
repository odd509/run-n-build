using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButton : MonoBehaviour
{
    public PlayerStatsSO PlayerStatsSo;
    
    public void LoadMenu()
    {
        SceneManager.LoadScene(0);
        PlayerStatsSo.totalMoney += 1000;
    }
}
