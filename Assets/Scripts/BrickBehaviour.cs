using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickBehaviour : MonoBehaviour
{
    public GameObject player;
    public GameObject brickHolder;
    public GameObject jointBrick = null;
    public GameObject tailBrick = null;
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnJointBreak(float breakForce)
    {   
        Debug.Log(this);
        
        if (tailBrick.CompareTag("BrickHolder"))
        {
            brickHolder.GetComponent<BrickHolder>().jointBrick = null;
        }
        else
        {
            tailBrick.GetComponent<BrickBehaviour>().jointBrick = null;
        }

        jointBrick.GetComponent<CharacterJoint>().breakForce = 0;
    }
}
