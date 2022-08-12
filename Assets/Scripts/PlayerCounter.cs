using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCounter : MonoBehaviour
{
    public Dictionary<GameObject, int> counter = new Dictionary<GameObject, int>();
    public Dictionary<GameObject, TextMeshProUGUI> TMPHolder = new Dictionary<GameObject, TextMeshProUGUI>();

    [Header("Stats")] 
    //public float startMoney;
    private float currentMoney;
    public FloatSO startMoneySO;
    
    [Header("UI Texts")]
    public TextMeshProUGUI brickTMP;
    public TextMeshProUGUI doorTMP;
    public TextMeshProUGUI playerMoneyTMP;
    
    
    [Header("Prefabs")]
    public GameObject brick;
    public GameObject door;
    [Header("UI Effects")]
    public GameObject brickParent;
    public GameObject doorParent;
    
    

    private void Start()
    {
        counter[brick] = 0;
        counter[door] = 0;

        TMPHolder[brick] = brickTMP;
        TMPHolder[door] = doorTMP;

        currentMoney = startMoneySO.Value;
        playerMoneyTMP.text = startMoneySO.Value + "$";


    }

    private void Update()
    {
    }

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



        counter[corObject] = key.gameObject.GetComponent<Price>().price;
        TMPHolder[corObject].text = counter[corObject].ToString() + "$";

        currentMoney -= counter[corObject];
        playerMoneyTMP.text = currentMoney + "$";
        corParent.GetComponent<UIEffects>().PickUp();


    }
    
    private void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.CompareTag("Collectable"))
        {
            //brickHolder.GetComponent<BrickHolder>().addJoint(collision.gameObject);

            GameObject collisionParent = collision.gameObject.transform.parent.gameObject;

            if (currentMoney >= collision.gameObject.GetComponent<Price>().price)
            {
                Counter(collision.gameObject);
            
                Destroy(collisionParent.gameObject);
            }
            
            
            
            
            //collision.gameObject.tag = "Collected";
        }
    }
}
