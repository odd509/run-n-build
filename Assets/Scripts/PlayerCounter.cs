using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerCounter : MonoBehaviour
{
    
    public Dictionary<Collectable.CollectableType, TextMeshProUGUI> TMPHolder = new Dictionary<Collectable.CollectableType, TextMeshProUGUI>();
    public Dictionary<Collectable.CollectableType, GameObject> placeHolder = new Dictionary<Collectable.CollectableType, GameObject>();

    public Dictionary<Collectable.CollectableType, GameObject> playerInventory =
        new Dictionary<Collectable.CollectableType, GameObject>();


    [Header("Stats")] 
    //public float startMoney;
    private float currentMoney;
    public PlayerStatsSO playerStatsSO;
    
    [Header("UI Texts")]
    public TextMeshProUGUI roofTMP;
    public TextMeshProUGUI wallTMP;
    public TextMeshProUGUI windowTMP;
    public TextMeshProUGUI doorTMP;
    public TextMeshProUGUI playerMoneyTMP;
    
    [Header("UI Model Placeholders")]
    public GameObject roofPlaceholder;
    public GameObject wallPlaceholder;
    public GameObject windowPlaceholder;
    public GameObject doorPlaceholder;
    
    
    
    [Header("Prefabs")]
    public GameObject brick;
    public GameObject door;
    [Header("UI Effects")]
    public GameObject brickParent;
    public GameObject doorParent;

    public GameObject materialSpawner;

    private void Start()
    {
        

        TMPHolder[Collectable.CollectableType.Door] = doorTMP;
        TMPHolder[Collectable.CollectableType.Roof] = roofTMP;
        TMPHolder[Collectable.CollectableType.Wall] = wallTMP;
        TMPHolder[Collectable.CollectableType.Window] = windowTMP;
        
        placeHolder[Collectable.CollectableType.Door] = doorPlaceholder;
        placeHolder[Collectable.CollectableType.Roof] = roofPlaceholder;
        placeHolder[Collectable.CollectableType.Wall] = wallPlaceholder;
        placeHolder[Collectable.CollectableType.Window] = windowPlaceholder;

        UpdatePlayerMoney(playerStatsSO.GetStartingMoney());

    }

    private void Update()
    {
    }
/*
    public void Counter(GameObject key)
    {
        GameObject corObject;
        GameObject corParent;

        if (key.name.StartsWith("Door"))
        {
            corObject = door;
            corParent = doorParent;
        }
        else if (key.name.StartsWith("Brick"))
        {
            corObject = brick;
            corParent = brickParent;
        }
        else
        {
            corObject = door;
            corParent = doorParent;

        }



        counter[corObject] = key.gameObject.GetComponent<Collectable>().price;
        TMPHolder[corObject].text = counter[corObject].ToString() + "$";

        currentMoney -= counter[corObject];
        playerMoneyTMP.text = currentMoney + "$";
        corParent.GetComponent<UIEffects>().PickUp();


    }*/

    private void UpdatePlayerMoney(float newMoney)
    {
        currentMoney = newMoney;
        playerMoneyTMP.text = currentMoney + "$";
    }


    void PickUp(GameObject item)
    {
        UpdatePlayerMoney(currentMoney - item.GetComponent<Collectable>().price);
        
        playerInventory[item.GetComponent<Collectable>().type] = item;

        TMPHolder[item.GetComponent<Collectable>().type].text = item.GetComponent<Collectable>().price + "$";
        
        var placeHolderGO = placeHolder[item.GetComponent<Collectable>().type];
        
        
        //clear previous ones
        foreach (Transform child in placeHolderGO.transform)
        {
            Destroy(child.gameObject);
        }
        
        item.transform.position = placeHolderGO.transform.position;
        item.transform.rotation = placeHolderGO.transform.rotation;
        item.transform.parent = placeHolderGO.transform;
        item.transform.Find("Price Canvas").gameObject.SetActive(false);
        item.GetComponent<Collectable>().enabled = false;
        item.transform.GetChild(1).gameObject.layer = LayerMask.NameToLayer("UI");
        item.transform.GetChild(1).gameObject.GetComponent<MeshRenderer>().shadowCastingMode = ShadowCastingMode.Off;
        
        item.transform.localScale *= 0.2f;
        
        placeHolderGO.GetComponent<Animator>().SetTrigger("Scale");
        
        
        if (item.GetComponent<Collectable>().pairItem != null)
        {
            Destroy(item.GetComponent<Collectable>().pairItem);
        }

    }
    
    
    private void OnCollisionEnter(Collision collision)
    {
        GameObject collisionParent = collision.gameObject.transform.parent.gameObject;
        if (collisionParent.CompareTag("Collectable"))
        {
            materialSpawner.GetComponent<MaterialSpawner>().SpawnPair();
            //brickHolder.GetComponent<BrickHolder>().addJoint(collision.gameObject);
            if (collisionParent.GetComponent<Collectable>().type == Collectable.CollectableType.Cash)
            {
                currentMoney += collisionParent.GetComponent<Collectable>().price;
                playerMoneyTMP.text = currentMoney + "$";
                if (collisionParent.GetComponent<Collectable>().pairItem != null)
                {
                    Destroy(collisionParent.GetComponent<Collectable>().pairItem);
                }
                Destroy(collisionParent);
                
                
            }
            

            else if (currentMoney >= collisionParent.GetComponent<Collectable>().price)
            {
                //Counter(collision.gameObject);
                PickUp(collisionParent);
                if (currentMoney == 0)
                {
                    ToSoldForScene();
                }
            }
            else
            {
                ToSoldForScene();

            }
            
            
            
            
            //collision.gameObject.tag = "Collected";
        }
    }

    private void DontDestroyInventory()
    {
        foreach (var pair in playerStatsSO.playerInventory)
        {
            if (pair.Value != null)
            {
                
                pair.Value.transform.parent = null;
                DontDestroyOnLoad(pair.Value);
            }
            
        }
    }

    public void ToSoldForScene()
    {
        playerStatsSO.playerInventory = playerInventory;
        DontDestroyInventory();
        SceneManager.LoadScene(2);
    }
    
}
