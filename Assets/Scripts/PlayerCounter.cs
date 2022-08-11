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

    public TextMeshProUGUI brickTMP;
    public TextMeshProUGUI doorTMP;

    public GameObject brick;
    public GameObject door;


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

        if (key.name.StartsWith("Door"))
        {
            corObject = door;
        }
        else if (key.name.StartsWith("Brick"))
        {
            corObject = brick;
        }
        else
        {
            corObject = door;
        }



        Debug.Log(corObject);
        counter[corObject] += 1;
        TMPHolder[corObject].text = counter[corObject].ToString();


    }
    
    private void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.CompareTag("Collectable"))
        {
            //brickHolder.GetComponent<BrickHolder>().addJoint(collision.gameObject);
            Debug.Log("zort");
            Counter(collision.gameObject);
            
            Destroy(collision.gameObject);
            
            
            //collision.gameObject.tag = "Collected";
        }
    }
}
