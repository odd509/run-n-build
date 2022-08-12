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

    
    
    [Header("UI Texts")]
    public TextMeshProUGUI brickTMP;
    public TextMeshProUGUI doorTMP;
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
        corParent.GetComponent<UIEffects>().PickUp();


    }
    
    private void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.CompareTag("Collectable"))
        {
            //brickHolder.GetComponent<BrickHolder>().addJoint(collision.gameObject);
            Debug.Log("zort");

            GameObject collisionParent = collision.gameObject.transform.parent.gameObject;

           
            
            Counter(collision.gameObject);
            
            Destroy(collisionParent.gameObject);
            
            
            //collision.gameObject.tag = "Collected";
        }
    }
}
