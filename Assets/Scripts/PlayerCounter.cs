using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCounter : MonoBehaviour
{
    public Dictionary<GameObject, int> counter = new Dictionary<GameObject, int>();

    private TextMeshProUGUI _brickTMP;

    public GameObject brick;
    public GameObject door;


    private void Start()
    {
        counter[brick] = 0;
        counter[door] = 0;
        



    }

    private void Update()
    {
    }

    public void Counter(GameObject key)
    {
        counter[key] += 1;
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Collectable"))
        {
            //brickHolder.GetComponent<BrickHolder>().addJoint(collision.gameObject);
            
            Counter(collision.gameObject);
            collision.gameObject.SetActive(false);
            
            
            //collision.gameObject.tag = "Collected";
        }
    }
}
